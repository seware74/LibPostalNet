using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

[assembly: ComVisible(false)]
[assembly: CLSCompliant(true)]

[assembly: SuppressMessage("Usage", "PC003:Native API not available in UWP", Justification = "This library is a native wrapper.")]
// , Scope = "member", Target = "~M:LibPostalNet.LibPostal.UnsafeNativeMethods.SetDllDirectory(System.String)~System.Boolean"
