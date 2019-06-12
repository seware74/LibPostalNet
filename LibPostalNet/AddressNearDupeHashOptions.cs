namespace LibPostalNet
{
    public unsafe partial class AddressNearDupeHashOptions
    {
        internal UnsafeNativeMethods.LibpostalNearDupeHashOptions _native;

        internal AddressNearDupeHashOptions()
        {
            _native = UnsafeNativeMethods.GetDefaultOptions();
        }

        public bool WithName
        {
            get { return _native._with_name != 0; }
            set { _native._with_name = (byte)(value ? 1 : 0); }
        }

        public bool WithAddress
        {
            get { return _native._with_address != 0; }
            set { _native._with_address = (byte)(value ? 1 : 0); }
        }

        public bool WithUnit
        {
            get { return _native._with_unit != 0; }
            set { _native._with_unit = (byte)(value ? 1 : 0); }
        }

        public bool WithCityOrEquivalent
        {
            get { return _native._with_city_or_equivalent != 0; }
            set { _native._with_city_or_equivalent = (byte)(value ? 1 : 0); }
        }

        public bool WithSmallContainingBoundaries
        {
            get { return _native._with_small_containing_boundaries != 0; }
            set { _native._with_small_containing_boundaries = (byte)(value ? 1 : 0); }
        }

        public bool WithPostalCode
        {
            get { return _native._with_postal_code != 0; }
            set { _native._with_postal_code = (byte)(value ? 1 : 0); }
        }

        public bool WithLatLon
        {
            get { return _native._with_latlon != 0; }
            set { _native._with_latlon = (byte)(value ? 1 : 0); }
        }

        public double Latitude
        {
            get { return _native._latitude; }
            set { _native._latitude = value; }
        }

        public double Longitude
        {
            get { return _native._longitude; }
            set { _native._longitude = value; }
        }

        public int GeohashPrecision
        {
            get { return (int)_native._geohash_precision; }
            set { _native._geohash_precision = (uint)value; }
        }

        public bool NameAndAddressKeys
        {
            get { return _native._name_and_address_keys != 0; }
            set { _native._name_and_address_keys = (byte)(value ? 1 : 0); }
        }

        public bool NameOnlyKeys
        {
            get { return _native._name_only_keys != 0; }
            set { _native._name_only_keys = (byte)(value ? 1 : 0); }
        }

        public bool AddressOnlyKeys
        {
            get { return _native._address_only_keys != 0; }
            set { _native._address_only_keys = (byte)(value ? 1 : 0); }
        }
    }
}
