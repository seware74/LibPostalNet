using System;
using System.Runtime.InteropServices;
using System.Security;

namespace LibPostalNet
{
    public partial class AddressParserResponse
    {
        internal class UnsafeNativeMethods
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_parse_address")]
            internal static extern IntPtr ParseAddress(IntPtr address, AddressParserOptions.UnsafeNativeMethods.LibpostalParserOptions options);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_address_parser_response_destroy")]
            internal static extern void AddressParserResponseDestroy(IntPtr self);

            [StructLayout(LayoutKind.Explicit, Size = 24)]
            protected internal struct LibpostalAddressParserResponse
            {
                [FieldOffset(0)]
                internal ulong _num_components;

                [FieldOffset(8)]
                internal IntPtr _components;

                [FieldOffset(16)]
                internal IntPtr _labels;

                //[SuppressUnmanagedCodeSecurity]
                //[DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                //    EntryPoint = "??0libpostal_address_parser_response@@QEAA@AEBU0@@Z")]
                //internal static extern IntPtr cctor(IntPtr instance, IntPtr _0);
            }
        }
    }
}
