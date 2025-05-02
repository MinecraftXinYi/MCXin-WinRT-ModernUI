using System;
using System.Runtime.InteropServices;

namespace MinecraftXinYi.Windows.ModernUI.Core.Direct;

using MetaData;

public static partial class CoreWindowNative
{
    [DllImport(WRTUINativeLibraryName.WU, EntryPoint = WRTUINativeLibraryEntryPoint.DefaultEntryPoint, SetLastError = true)]
    public static extern int PrivateCreateCoreWindow(
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
