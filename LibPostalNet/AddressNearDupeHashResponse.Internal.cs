using System;
using System.Runtime.InteropServices;
using System.Security;

namespace LibPostalNet
{
    public partial class AddressNearDupeHashResponse
    {
        internal class UnsafeNativeMethods
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_near_dupe_hashes")]
            internal static extern IntPtr NearHashAddress(ulong num_components, IntPtr labels, IntPtr values, AddressNearDupeHashOptions.UnsafeNativeMethods.LibpostalNearDupeHashOptions options, ref ulong num_hashes);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_near_dupe_hashes_languages")]
            internal static extern IntPtr NearHashAddress(ulong num_components, IntPtr labels, IntPtr values, AddressNearDupeHashOptions.UnsafeNativeMethods.LibpostalNearDupeHashOptions options, ulong num_languages, IntPtr languages, ref ulong num_hashes);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_place_languages")]
            internal static extern IntPtr PlaceLanguages(ulong num_components, IntPtr labels, IntPtr values, ref ulong num_languages);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_expansion_array_destroy")]
            internal static extern void ExpansionArrayDestroy(IntPtr expansions, ulong num_components);
        }
    }
}
