using System;
using System.Runtime.InteropServices;
using System.Security;

namespace LibPostalNet
{
    public partial class LibPostal
    {
        protected internal struct UnsafeNativeMethods
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern IntPtr LoadLibrary(string lpFileName);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool SetDllDirectory(string lpPathName);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_parser_print_features")]
            [return: MarshalAs(UnmanagedType.I1)]
            internal static extern bool ParserPrintFeatures([MarshalAs(UnmanagedType.I1)] bool print_features);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_setup")]
            [return: MarshalAs(UnmanagedType.I1)]
            internal static extern bool Setup();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_setup_datadir")]
            [return: MarshalAs(UnmanagedType.I1)]
            internal static extern bool SetupDatadir(IntPtr datadir);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_teardown")]
            internal static extern void Teardown();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_setup_parser")]
            [return: MarshalAs(UnmanagedType.I1)]
            internal static extern bool SetupParser();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_setup_parser_datadir")]
            [return: MarshalAs(UnmanagedType.I1)]
            internal static extern bool SetupParserDatadir(IntPtr datadir);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_teardown_parser")]
            internal static extern void TeardownParser();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_setup_language_classifier")]
            [return: MarshalAs(UnmanagedType.I1)]
            internal static extern bool SetupLanguageClassifier();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_setup_language_classifier_datadir")]
            [return: MarshalAs(UnmanagedType.I1)]
            internal static extern bool SetupLanguageClassifierDatadir(IntPtr datadir);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_teardown_language_classifier")]
            internal static extern void TeardownLanguageClassifier();
        }
    }
}
