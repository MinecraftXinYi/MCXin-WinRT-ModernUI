using System;
using System.Runtime.InteropServices;

namespace MinecraftXinYi.Windows.ModernUI.Core.Direct;

using MetaData;

public static partial class CoreWindowNative
{
    [LibraryImport(WinRTUILibraryName.WU, EntryPoint = "#1500", StringMarshalling = StringMarshalling.Utf16)]
    public static partial int PrivateCreateCoreWindow(
        CoreWindowType windowType,
        string windowTitle,
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
