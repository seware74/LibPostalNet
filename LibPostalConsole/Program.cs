using System;
using System.Collections.Generic;
using LibPostalNet;

namespace LibPostalConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string address = "781 Franklin Ave Crown Heights Brooklyn NYC NY 11216 USA";
            double
                latitude = 51.50d,
                longitude = -0.14d;

            Console.WriteLine("Loading LibPostal...");
            LibPostal libPostal = LibPostal.GetInstance();
            libPostal.LoadParser();
            libPostal.LoadLanguageClassifier();
            //libPostal.PrintFeatures = true;
            Console.WriteLine("Loaded.");

            // Parser Tests
            Console.WriteLine();
            Console.WriteLine("Parser Test:");
            AddressParserOptions parserOptions = libPostal.GetAddressParserDefaultOptions();
            using (AddressParserResponse response = libPostal.ParseAddress(address, parserOptions))
            {
                foreach (KeyValuePair<string, string> x in response.Results)
                {
                    Console.WriteLine("{0}: {1}", x.Key, x.Value);
                }
                Console.WriteLine();

                //Console.WriteLine("JSON:");
                //Console.WriteLine(response.ToJSON());
                //Console.WriteLine();

                //Console.WriteLine("XML:");
                //Console.WriteLine(response.ToXML());
                //Console.WriteLine();

                // Geo Hash Tests
                Console.WriteLine();
                Console.WriteLine("GeoHash Test:");
                AddressNearDupeHashOptions nearHashOptions = libPostal.GetNearDupeHashDefaultOptions();
                using (AddressNearDupeHashResponse nearHashresponse = libPostal.NearDupeHashAddress(
                    response,
                    latitude,
                    longitude,
                    nearHashOptions))
                {
                    foreach (var hash in nearHashresponse.Hashes)
                    {
                        Console.WriteLine("{0}", hash);
                    }
                    Console.WriteLine();

                    //Console.WriteLine("JSON:");
                    //Console.WriteLine(response.ToJSON());
                    //Console.WriteLine();

                    //Console.WriteLine("XML:");
                    //Console.WriteLine(response.ToXML());
                    //Console.WriteLine();
                }
            }

            //// Expansion Tests
            //Console.WriteLine();
            //Console.WriteLine("Expansion Test:");
            //var expansionOptions = libPostal.GetAddressExpansionDefaultOptions();
            //using (var expansion = libPostal.ExpandAddress(address, expansionOptions))
            //{
            //    foreach (var x in expansion.Expansions)
            //    {
            //        Console.WriteLine("{0}", x);
            //    }
            //    Console.WriteLine();

            //    Console.WriteLine("JSON:");
            //    Console.WriteLine(expansion.ToJSON());
            //    Console.WriteLine();

            //    //Console.WriteLine("XML:");
            //    //Console.WriteLine(expansion.ToXML());
            //    //Console.WriteLine();
            //}

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
