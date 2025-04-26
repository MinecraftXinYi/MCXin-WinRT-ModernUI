#if NET8_0_OR_GREATER
using WinRT;
#else
using System;
using System.Runtime.InteropServices;
#endif
using Windows.UI.Xaml.Hosting;

namespace MinecraftXinYi.Windows.ModernUI.Core;

public static class DesktopWindowXamlSourceInterop
{
    public static IDesktopWindowXamlSourceNative GetNative(this DesktopWindowXamlSource windowXamlSource)
    {
#if NET8_0_OR_GREATER
        return windowXamlSource.As<IDesktopWindowXamlSourceNative>();
#else
        IntPtr baseObjPtr = Marshal.GetIUnknownForObject(windowXamlSource);
        try
        {
            return (IDesktopWindowXamlSourceNative)Marshal.GetTypedObjectForIUnknown(baseObjPtr, typeof(IDesktopWindowXamlSourceNative));
        }
        finally
        {
            Marshal.Release(baseObjPtr);
        }
#endif
    }

    public static IDesktopWindowXamlSourceNative2 GetNative2(this DesktopWindowXamlSource windowXamlSource)
    {
#if NET8_0_OR_GREATER
        return windowXamlSource.As<IDesktopWindowXamlSourceNative2>();
#else
        IntPtr baseObjPtr = Marshal.GetIUnknownForObject(windowXamlSource);
        try
        {
            return (IDesktopWindowXamlSourceNative2)Marshal.GetTypedObjectForIUnknown(baseObjPtr, typeof(IDesktopWindowXamlSourceNative2));
        }
        finally
        {
            Marshal.Release(baseObjPtr);
        }
#endif
    }
}
