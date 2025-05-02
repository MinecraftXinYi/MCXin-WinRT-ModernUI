using System;
using System.Runtime.InteropServices;
using Windows.UI.Core;

namespace MinecraftXinYi.Windows.ModernUI.Core.Direct;

public static partial class CoreWindowInteropEx
{
    public static ICoreWindowInterop GetInterop(this CoreWindow coreWindow)
    {
        IntPtr baseObjPtr = Marshal.GetIUnknownForObject(coreWindow);
        try
        {
            return (ICoreWindowInterop)Marshal.GetTypedObjectForIUnknown(baseObjPtr, typeof(ICoreWindowInterop));
        }
        finally
        {
            Marshal.Release(baseObjPtr);
        }
    }
}
