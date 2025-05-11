using System;
using System.Runtime.InteropServices;

namespace MinecraftXinYi.Windows.ModernUI.Core.Direct;

using MetaData;

public static partial class CoreWindowNative
{
    [DllImport(WinRTUILibraryName.WU, EntryPoint = "#1500")]
    public static extern int PrivateCreateCoreWindow(
        CoreWindowType windowType,
        [MarshalAs(UnmanagedType.HString)] string windowTitle,
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
