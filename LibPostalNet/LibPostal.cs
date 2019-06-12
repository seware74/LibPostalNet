using System;
using System.IO;
using System.Runtime.InteropServices;

namespace LibPostalNet
{
    public unsafe partial class LibPostal : IDisposable
    {
        // Instance Logic
        private static LibPostal s_instance;
        public static LibPostal GetInstance() => GetInstance(null);
        public static LibPostal GetInstance(string dataDir) { return s_instance ?? (s_instance = new LibPostal(dataDir)); }

        // Library Logic
        private IntPtr _dataDirPtr;
        private string _dataDirStr;
        private bool _printFeatures;

        public string DataDir
        {
            get { return _dataDirStr; }
            set
            {
                if (!string.IsNullOrEmpty(_dataDirStr = value))
                {
                    if (_dataDirPtr != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(_dataDirPtr);
                        _dataDirPtr = IntPtr.Zero;
                    }
                    _dataDirPtr = MarshalUTF8.StringToPtr(_dataDirStr);
                }
            }
        }
        public bool IsLoaded { get; private set; }
        public bool IsParserLoaded { get; private set; }
        public bool IsLanguageClassifierLoaded { get; private set; }
        public bool PrintFeatures
        {
            get { return _printFeatures; }
            set
            {
                if (IsParserLoaded)
                {
                    _printFeatures = value;
                    UnsafeNativeMethods.ParserPrintFeatures(_printFeatures);
                }
                else
                {
                    throw new InvalidOperationException("The LibPostal Parser must be loaded first.");
                }
            }
        }

        static LibPostal()
        {
            try
            {
                UriBuilder uri = new UriBuilder(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
                string path = Path.GetDirectoryName(Uri.UnescapeDataString(uri.Path));
                if (!string.IsNullOrEmpty(path))
                {
#if NET35
                    bool is64bit = IntPtr.Size == 8;
#else
                    bool is64bit = Environment.Is64BitProcess;
#endif
                    path = Path.Combine(path, is64bit ? "x64" : "x86");
                    UnsafeNativeMethods.SetDllDirectory(path);
                    IntPtr moduleHandle = UnsafeNativeMethods.LoadLibrary("libpostal");
                    if (moduleHandle == IntPtr.Zero)
                    {
                        var lastError = Marshal.GetLastWin32Error();
                        throw new System.ComponentModel.Win32Exception(lastError);
                    }
                }
            }
            catch (Exception) { }
        }
        private LibPostal(string dataDir)
        {
            IsLoaded = string.IsNullOrEmpty(DataDir = dataDir) ?
                UnsafeNativeMethods.Setup() :
                UnsafeNativeMethods.SetupDatadir(_dataDirPtr);
        }
        ~LibPostal() { Dispose(false); }
        public void Dispose() { Dispose(true); GC.SuppressFinalize(this); }
        protected virtual void Dispose(bool disposing)
        {
            s_instance = null;
            if (IsLoaded)
            {
                UnsafeNativeMethods.Teardown();
                IsLoaded = false;
            }
            if (IsParserLoaded)
            {
                UnsafeNativeMethods.TeardownParser();
                IsParserLoaded = false;
            }
            if (IsLanguageClassifierLoaded)
            {
                UnsafeNativeMethods.TeardownLanguageClassifier();
                IsLanguageClassifierLoaded = false;
            }
            if (_dataDirPtr != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_dataDirPtr);
                _dataDirPtr = IntPtr.Zero;
            }
        }

        public void LoadParser()
        {
            if (!IsParserLoaded)
            {
                IsParserLoaded = string.IsNullOrEmpty(DataDir) ?
                    UnsafeNativeMethods.SetupParser() :
                    UnsafeNativeMethods.SetupParserDatadir(_dataDirPtr);
            }
        }
        public void LoadLanguageClassifier()
        {
            if (!IsLanguageClassifierLoaded)
            {
                IsLanguageClassifierLoaded = string.IsNullOrEmpty(DataDir) ?
                    UnsafeNativeMethods.SetupLanguageClassifier() :
                    UnsafeNativeMethods.SetupLanguageClassifierDatadir(_dataDirPtr);
            }
        }

        public AddressExpansionOptions GetAddressExpansionDefaultOptions()
        {
            return new AddressExpansionOptions();
        }
        public AddressExpansionResponse ExpandAddress(string input, AddressExpansionOptions options)
        {
            if (!IsLanguageClassifierLoaded)
            { LoadLanguageClassifier(); }
            return new AddressExpansionResponse(input, options);
        }

        public AddressParserOptions GetAddressParserDefaultOptions()
        {
            return new AddressParserOptions();
        }
        public AddressParserResponse ParseAddress(string address, AddressParserOptions options)
        {
            if (!IsParserLoaded)
            { LoadParser(); }
            return new AddressParserResponse(address, options);
        }

        public AddressNearDupeHashOptions GetNearDupeHashDefaultOptions()
        {
            return new AddressNearDupeHashOptions();
        }
        public AddressNearDupeHashResponse NearDupeHashAddress(AddressParserResponse parserResponse, AddressNearDupeHashOptions options)
            => NearDupeHashAddress(parserResponse, 0, 0, options);
        public AddressNearDupeHashResponse NearDupeHashAddress(AddressParserResponse parserResponse, double latitude, double longitude, AddressNearDupeHashOptions options)
        {
            if (!IsLanguageClassifierLoaded)
            { LoadLanguageClassifier(); }
            return new AddressNearDupeHashResponse(parserResponse, latitude, longitude, options);
        }
    }
}
