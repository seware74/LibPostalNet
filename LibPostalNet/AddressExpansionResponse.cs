using Newtonsoft.Json.Linq;
using System;
using System.Runtime.InteropServices;
using System.Xml;

namespace LibPostalNet
{
    public unsafe partial class AddressExpansionResponse : IDisposable
    {
        private IntPtr _instance;
        private IntPtr _inputString;
        private ulong _numExpansions;

        public string[] Expansions { get; private set; }

        internal AddressExpansionResponse(string input, AddressExpansionOptions options)
        {
            if (options is null) throw new NullReferenceException();
            _inputString = MarshalUTF8.StringToPtr(input);
            _instance = UnsafeNativeMethods.ExpandAddress(_inputString, options._native, ref _numExpansions);
            if (_instance == IntPtr.Zero || _instance.ToPointer() == null)
                return;

            Expansions = new string[_numExpansions];
            for (int x = 0; x < (int)_numExpansions; x++)
            {
                int offset = x * Marshal.SizeOf(typeof(IntPtr));
                Expansions[x] = MarshalUTF8.PtrToString(Marshal.ReadIntPtr(_instance, offset));
            }
        }

        ~AddressExpansionResponse() { Dispose(false); }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_instance != IntPtr.Zero)
            {
                UnsafeNativeMethods.ExpansionArrayDestroy(_instance, _numExpansions);
                _instance = IntPtr.Zero;
            }
            if (_inputString != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_inputString);
                _inputString = IntPtr.Zero;
            }
        }

        public string ToJSON()
        {
            var json = new JArray();
            foreach (var expansion in Expansions)
            {
                json.Add(new JValue(expansion));
            }
            return json.ToString(Newtonsoft.Json.Formatting.None);
        }

        public string ToXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", string.Empty, string.Empty));
            XmlElement address = doc.CreateElement("address");
            foreach (var expansion in Expansions)
            {
                XmlElement elem = doc.CreateElement("expansion");
                elem.AppendChild(doc.CreateTextNode(expansion));
                address.AppendChild(elem);
            }
            doc.AppendChild(address);
            return doc.OuterXml;
        }
    }
}
