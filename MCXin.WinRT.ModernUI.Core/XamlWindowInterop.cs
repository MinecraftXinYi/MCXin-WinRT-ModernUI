#if NET8_0_OR_GREATER
using WinRT;
#else
using System;
using System.Runtime.InteropServices;
#endif
using Windows.UI.Xaml;

namespace MinecraftXinYi.Windows.ModernUI.Core;

public static partial class XamlWindowInterop
{
    public static IWindowPrivate GetInterop(this Window window)
    {
#if NET8_0_OR_GREATER
        return window.As<IWindowPrivate>();
#else
        IntPtr baseObjPtr = Marshal.GetIUnknownForObject(window);
        try
        {
            return (IWindowPrivate)Marshal.GetTypedObjectForIUnknown(baseObjPtr, typeof(IWindowPrivate));
        }
        finally
        {
            Marshal.Release(baseObjPtr);
        }
#endif
    }
}
