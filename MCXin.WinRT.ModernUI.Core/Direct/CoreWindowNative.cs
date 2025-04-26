using System;
using System.Runtime.InteropServices;

namespace MinecraftXinYi.Windows.ModernUI.Core.Direct;

using MetaData;

public static partial class CoreWindowNative
{
#if NET8_0_OR_GREATER
    [LibraryImport
#else
    [DllImport
#endif
        (WRTUINativeLibraryName.WU, EntryPoint = WRTUINativeLibraryEntryPoint.DefaultEntryPoint, SetLastError = true), PreserveSig]
    public static
#if NET8_0_OR_GREATER
        partial
#else
        extern
#endif
        int PrivateCreateCoreWindow(
        CoreWindowType windowType,
        [MarshalAs(UnmanagedType.BStr)] string windowTitle,
        int x,
        int y,
        uint width,
        uint height,
        uint dwAttributes,
        nint hOwnerWindow,
        Guid riid,
        out nint pWindow
    );
}
