using System;
using System.Runtime.InteropServices;
using System.Security;

namespace LibPostalNet
{
    public partial class AddressExpansionResponse
    {
        internal class UnsafeNativeMethods
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_expand_address")]
            internal static extern IntPtr ExpandAddress(IntPtr input, AddressExpansionOptions.UnsafeNativeMethods.LibpostalExpansionOptions options, ref ulong n);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_expansion_array_destroy")]
            internal static extern void ExpansionArrayDestroy(IntPtr expansions, ulong n);
        }
    }
}
