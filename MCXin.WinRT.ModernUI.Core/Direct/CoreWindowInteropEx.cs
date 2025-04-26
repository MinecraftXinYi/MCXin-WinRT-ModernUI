#if NET8_0_OR_GREATER
using WinRT;
#else
using System;
using System.Runtime.InteropServices;
#endif
using Windows.UI.Core;

namespace MinecraftXinYi.Windows.ModernUI.Core.Direct;

public static partial class CoreWindowInteropEx
{
    public static ICoreWindowInterop GetInterop(this CoreWindow coreWindow)
    {
#if NET8_0_OR_GREATER
        return coreWindow.As<ICoreWindowInterop>();
#else
        IntPtr baseObjPtr = Marshal.GetIUnknownForObject(coreWindow);
        try
        {
            return (ICoreWindowInterop)Marshal.GetTypedObjectForIUnknown(baseObjPtr, typeof(ICoreWindowInterop));
        }
        finally
        {
            Marshal.Release(baseObjPtr);
        }
#endif
    }
}
