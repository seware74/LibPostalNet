
namespace LibPostalNet
{
    public unsafe partial class AddressParserOptions
    {
        internal UnsafeNativeMethods.LibpostalParserOptions _native;

        internal AddressParserOptions()
        {
            _native = UnsafeNativeMethods.GetAddressParserDefaultOptions();
        }

        public string Language
        {
            get { return MarshalUTF8.PtrToString(_native._language); }
            set { _native._language = MarshalUTF8.StringToPtr(value); }
        }

        public string Country
        {
            get { return MarshalUTF8.PtrToString(_native._country); }
            set { _native._country = MarshalUTF8.StringToPtr(value); }
        }
    }
}
