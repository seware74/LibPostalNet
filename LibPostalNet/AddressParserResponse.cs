using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml;

namespace LibPostalNet
{
    public unsafe partial class AddressParserResponse : IDisposable
    {
        internal IntPtr _instance;
        private IntPtr _inputString;

        internal AddressParserResponse(string address, AddressParserOptions options)
        {
            if (options is null) throw new NullReferenceException();
            _inputString = MarshalUTF8.StringToPtr(address);
            _instance = UnsafeNativeMethods.ParseAddress(_inputString, options._native);
            if (_instance == IntPtr.Zero || _instance.ToPointer() == null)
                return;
        }

        ~AddressParserResponse() { Dispose(false); }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_instance != IntPtr.Zero)
            {
                UnsafeNativeMethods.AddressParserResponseDestroy(_instance);
                _instance = IntPtr.Zero;
            }
            if (_inputString != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_inputString);
                _inputString = IntPtr.Zero;
            }
        }

        public long NumComponents
        {
            get
            {
                return (long)((UnsafeNativeMethods.LibpostalAddressParserResponse*)_instance)->_num_components;
            }
        }

        public string[] Components
        {
            get
            {
                long n = NumComponents;
                IntPtr components = ((UnsafeNativeMethods.LibpostalAddressParserResponse*)_instance)->_components;
                string[] ret = new string[n];
                for (int x = 0; x < n; x++)
                {
                    int offset = x * Marshal.SizeOf(typeof(IntPtr));
                    ret[x] = MarshalUTF8.PtrToString(Marshal.ReadIntPtr(components, offset));
                }
                return ret;
            }
        }

        public string[] Labels
        {
            get
            {
                long n = NumComponents;
                IntPtr labels = ((UnsafeNativeMethods.LibpostalAddressParserResponse*)_instance)->_labels;
                string[] ret = new string[n];
                for (int x = 0; x < n; x++)
                {
                    int offset = x * Marshal.SizeOf(typeof(IntPtr));
                    ret[x] = MarshalUTF8.PtrToString(Marshal.ReadIntPtr(labels, offset));
                }
                return ret;
            }
        }

        public List<KeyValuePair<string, string>> Results
        {
            get
            {
                var _results = new List<KeyValuePair<string, string>>();

                IntPtr
                    labels = ((UnsafeNativeMethods.LibpostalAddressParserResponse*)_instance)->_labels,
                    components = ((UnsafeNativeMethods.LibpostalAddressParserResponse*)_instance)->_components
                ;

                long n = NumComponents;
                for (int x = 0; x < n; x++)
                {
                    int offset = x * Marshal.SizeOf(typeof(IntPtr));
                    _results.Add(new KeyValuePair<string, string>(
                        MarshalUTF8.PtrToString(Marshal.ReadIntPtr(labels, offset)),
                        MarshalUTF8.PtrToString(Marshal.ReadIntPtr(components, offset))
                    ));
                }
                return _results;
            }
        }

        public string ToJSON()
        {
            var json = new JObject();
            var grp = Results.GroupBy(K => K.Key, V => V.Value, (key, g) => new { Key = key, Value = g.ToArray() });
            foreach (var x in grp)
            {
                var values = new JArray();
                foreach (var y in x.Value)
                {
                    values.Add(new JValue(y));
                }
                json.Add(new JProperty(x.Key, values));
            }
            return json.ToString(Newtonsoft.Json.Formatting.None);
        }

        public string ToXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", string.Empty, string.Empty));
            XmlElement address = doc.CreateElement("address");
            foreach (KeyValuePair<string, string> x in Results)
            {
                XmlElement elem = doc.CreateElement(x.Key);
                elem.AppendChild(doc.CreateTextNode(x.Value));
                address.AppendChild(elem);
            }
            doc.AppendChild(address);
            return doc.OuterXml;
        }
    }
}
