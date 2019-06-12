using System;
using System.Runtime.InteropServices;

namespace LibPostalNet
{
    public unsafe partial class AddressExpansionOptions
    {
        internal UnsafeNativeMethods.LibpostalExpansionOptions _native;

        internal AddressExpansionOptions()
        {
            _native = UnsafeNativeMethods.GetDefaultOptions();
        }

        public string[] Languages
        {
            get
            {
                long n = NumLanguages;
                IntPtr languages = _native._languages;
                string[] ret = new string[n];
                for (int x = 0; x < n; x++)
                {
                    int offset = x * Marshal.SizeOf(typeof(IntPtr));
                    ret[x] = MarshalUTF8.PtrToString(Marshal.ReadIntPtr(languages, offset));
                }
                return ret;
            }
            //set
            //{
            //    ((Internal*)Instance)->languages = (IntPtr)value;
            //    NumLanguages = value.Length;
            //}
        }

        public long NumLanguages
        {
            get { return (long)_native._num_languages; }
            private set { _native._num_languages = (ulong)value; }
        }

        public AddressComponents AddressComponents
        {
            get { return (AddressComponents)_native._address_components; }
            set { _native._address_components = (ushort)value; }
        }

        public bool LatinAscii
        {
            get { return _native._latin_ascii != 0; }
            set { _native._latin_ascii = (byte)(value ? 1 : 0); }
        }

        public bool Transliterate
        {
            get { return _native._transliterate != 0; }
            set { _native._transliterate = (byte)(value ? 1 : 0); }
        }

        public bool StripAccents
        {
            get { return _native._strip_accents != 0; }
            set { _native._strip_accents = (byte)(value ? 1 : 0); }
        }

        public bool Decompose
        {
            get { return _native._decompose != 0; }
            set { _native._decompose = (byte)(value ? 1 : 0); }
        }

        public bool Lowercase
        {
            get { return _native._lowercase != 0; }
            set { _native._lowercase = (byte)(value ? 1 : 0); }
        }

        public bool TrimString
        {
            get { return _native._trim_string != 0; }
            set { _native._trim_string = (byte)(value ? 1 : 0); }
        }

        public bool DropParentheticals
        {
            get { return _native._drop_parentheticals != 0; }
            set { _native._drop_parentheticals = (byte)(value ? 1 : 0); }
        }

        public bool ReplaceNumericHyphens
        {
            get { return _native._replace_numeric_hyphens != 0; }
            set { _native._replace_numeric_hyphens = (byte)(value ? 1 : 0); }
        }

        public bool DeleteNumericHyphens
        {
            get { return _native._delete_numeric_hyphens != 0; }
            set { _native._delete_numeric_hyphens = (byte)(value ? 1 : 0); }
        }

        public bool SplitAlphaFromNumeric
        {
            get { return _native._split_alpha_from_numeric != 0; }
            set { _native._split_alpha_from_numeric = (byte)(value ? 1 : 0); }
        }

        public bool ReplaceWordHyphens
        {
            get { return _native._replace_word_hyphens != 0; }
            set { _native._replace_word_hyphens = (byte)(value ? 1 : 0); }
        }

        public bool DeleteWordHyphens
        {
            get { return _native._delete_word_hyphens != 0; }
            set { _native._delete_word_hyphens = (byte)(value ? 1 : 0); }
        }

        public bool DeleteFinalPeriods
        {
            get { return _native._delete_final_periods != 0; }
            set { _native._delete_final_periods = (byte)(value ? 1 : 0); }
        }

        public bool DeleteAcronymPeriods
        {
            get { return _native._delete_acronym_periods != 0; }
            set { _native._delete_acronym_periods = (byte)(value ? 1 : 0); }
        }

        public bool DropEnglishPossessives
        {
            get { return _native._drop_english_possessives != 0; }
            set { _native._drop_english_possessives = (byte)(value ? 1 : 0); }
        }

        public bool DeleteApostrophes
        {
            get { return _native._delete_apostrophes != 0; }
            set { _native._delete_apostrophes = (byte)(value ? 1 : 0); }
        }

        public bool ExpandNumex
        {
            get { return _native._expand_numex != 0; }
            set { _native._expand_numex = (byte)(value ? 1 : 0); }
        }

        public bool RomanNumerals
        {
            get { return _native._roman_numerals != 0; }
            set { _native._roman_numerals = (byte)(value ? 1 : 0); }
        }
    }
}
