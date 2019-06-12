using System;
using System.Runtime.InteropServices;
using System.Security;

namespace LibPostalNet
{
    public partial class AddressParserOptions
    {
        internal class UnsafeNativeMethods
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_get_address_parser_default_options")]
            internal static extern LibpostalParserOptions GetAddressParserDefaultOptions();

            [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 16)]
            protected internal struct LibpostalParserOptions
            {
                [FieldOffset(0)]
                internal IntPtr _language;

                [FieldOffset(8)]
                internal IntPtr _country;

                //[SuppressUnmanagedCodeSecurity]
                //[DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                //    EntryPoint = "??0libpostal_address_parser_options@@QEAA@AEBU0@@Z")]
                //internal static extern IntPtr cctor(IntPtr instance, IntPtr _0);
            }
        }
    }
}
