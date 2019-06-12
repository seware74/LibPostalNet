using System;
using System.Runtime.InteropServices;
using System.Security;

namespace LibPostalNet
{
    public partial class AddressExpansionOptions
    {
        internal class UnsafeNativeMethods
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                    EntryPoint = "libpostal_get_default_options")]
            internal static extern LibpostalExpansionOptions GetDefaultOptions();

            [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 36)]
            protected internal struct LibpostalExpansionOptions
            {
                [FieldOffset(0)]
                internal IntPtr _languages;

                [FieldOffset(8)]
                internal ulong _num_languages;

                [FieldOffset(16)]
                internal ushort _address_components;

                [FieldOffset(18)]
                internal byte _latin_ascii;

                [FieldOffset(19)]
                internal byte _transliterate;

                [FieldOffset(20)]
                internal byte _strip_accents;

                [FieldOffset(21)]
                internal byte _decompose;

                [FieldOffset(22)]
                internal byte _lowercase;

                [FieldOffset(23)]
                internal byte _trim_string;

                [FieldOffset(24)]
                internal byte _drop_parentheticals;

                [FieldOffset(25)]
                internal byte _replace_numeric_hyphens;

                [FieldOffset(26)]
                internal byte _delete_numeric_hyphens;

                [FieldOffset(27)]
                internal byte _split_alpha_from_numeric;

                [FieldOffset(28)]
                internal byte _replace_word_hyphens;

                [FieldOffset(29)]
                internal byte _delete_word_hyphens;

                [FieldOffset(30)]
                internal byte _delete_final_periods;

                [FieldOffset(31)]
                internal byte _delete_acronym_periods;

                [FieldOffset(32)]
                internal byte _drop_english_possessives;

                [FieldOffset(33)]
                internal byte _delete_apostrophes;

                [FieldOffset(34)]
                internal byte _expand_numex;

                [FieldOffset(35)]
                internal byte _roman_numerals;

                //[SuppressUnmanagedCodeSecurity]
                //[DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                //    EntryPoint = "??0libpostal_normalize_options@@QEAA@AEBU0@@Z")]
                //internal static extern IntPtr cctor(IntPtr instance, IntPtr _0);
            }
        }
    }
}
