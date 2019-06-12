using System.Runtime.InteropServices;
using System.Security;

namespace LibPostalNet
{
    public partial class AddressNearDupeHashOptions
    {
        internal class UnsafeNativeMethods
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                    EntryPoint = "libpostal_get_near_dupe_hash_default_options")]
            internal static extern LibpostalNearDupeHashOptions GetDefaultOptions();

            [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 30)]
            protected internal struct LibpostalNearDupeHashOptions
            {
                [FieldOffset(0)]
                internal byte _with_name;

                [FieldOffset(1)]
                internal byte _with_address;

                [FieldOffset(2)]
                internal byte _with_unit;

                [FieldOffset(3)]
                internal byte _with_city_or_equivalent;

                [FieldOffset(4)]
                internal byte _with_small_containing_boundaries;

                [FieldOffset(5)]
                internal byte _with_postal_code;

                [FieldOffset(6)]
                internal byte _with_latlon;

                [FieldOffset(7)]
                internal double _latitude;

                [FieldOffset(15)]
                internal double _longitude;

                [FieldOffset(23)]
                internal uint _geohash_precision;

                [FieldOffset(27)]
                internal byte _name_and_address_keys;

                [FieldOffset(28)]
                internal byte _name_only_keys;

                [FieldOffset(29)]
                internal byte _address_only_keys;

                //[SuppressUnmanagedCodeSecurity]
                //[DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                //    EntryPoint = "??0libpostal_near_dupe_hash_options@@QEAA@AEBU0@@Z")]
                //internal static extern IntPtr cctor(IntPtr instance, IntPtr _0);
            }
        }
    }
}
