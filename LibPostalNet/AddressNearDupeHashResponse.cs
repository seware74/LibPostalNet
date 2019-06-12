using System;
using System.Runtime.InteropServices;

namespace LibPostalNet
{
    public unsafe partial class AddressNearDupeHashResponse : IDisposable
    {
        internal IntPtr _instance;
        private ulong _numHashes;

        public string[] Hashes { get; private set; }

        internal AddressNearDupeHashResponse(AddressParserResponse parserResponse, AddressNearDupeHashOptions options)
            : this(parserResponse, 0, 0, options) { }

        internal AddressNearDupeHashResponse(AddressParserResponse parserResponse, double latitude, double longitude, AddressNearDupeHashOptions options)
        {
            if (options is null)
            {
                throw new NullReferenceException();
            }

            var nativeResponse = (AddressParserResponse.UnsafeNativeMethods.LibpostalAddressParserResponse*)parserResponse._instance;

            // Language
            ulong _numLanguages = 0;
            IntPtr lang = UnsafeNativeMethods.PlaceLanguages(nativeResponse->_num_components, nativeResponse->_labels, nativeResponse->_components, ref _numLanguages);
            var languages = new string[_numLanguages];
            for (int x = 0; x < (int)_numLanguages; x++)
            {
                int offset = x * Marshal.SizeOf(typeof(IntPtr));
                languages[x] = MarshalUTF8.PtrToString(Marshal.ReadIntPtr(lang, offset));
            }


            // Geo Hash
            options.NameAndAddressKeys = true;
            options.AddressOnlyKeys = true;
            options.NameOnlyKeys = true;
            options.WithLatLon = true;
            options.WithCityOrEquivalent = true;
            options.WithSmallContainingBoundaries = true;
            options.WithPostalCode = true;
            options.WithAddress = true;
            options.WithName = true;
            options.WithUnit = false;
            options.GeohashPrecision = 4;
            options.Latitude = latitude;
            options.Longitude = longitude;

            _instance = UnsafeNativeMethods.NearHashAddress(nativeResponse->_num_components, nativeResponse->_labels, nativeResponse->_components, options._native, _numLanguages, lang, ref _numHashes);
            if (_instance == IntPtr.Zero || _instance.ToPointer() == null)
            {
                return;
            }

            Hashes = new string[_numHashes];
            for (int x = 0; x < (int)_numHashes; x++)
            {
                int offset = x * Marshal.SizeOf(typeof(IntPtr));
                Hashes[x] = MarshalUTF8.PtrToString(Marshal.ReadIntPtr(_instance, offset));
            }
        }


        ~AddressNearDupeHashResponse() { Dispose(false); }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_instance != IntPtr.Zero)
            {
                UnsafeNativeMethods.ExpansionArrayDestroy(_instance, _numHashes);
                _instance = IntPtr.Zero;
            }
        }
    }
}
