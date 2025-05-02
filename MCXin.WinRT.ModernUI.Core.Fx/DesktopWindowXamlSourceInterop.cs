using System;
using System.Runtime.InteropServices;
using Windows.UI.Xaml.Hosting;

namespace MinecraftXinYi.Windows.ModernUI.Core;

public static class DesktopWindowXamlSourceInterop
{
    public static IDesktopWindowXamlSourceNative GetNative(this DesktopWindowXamlSource windowXamlSource)
    {
        IntPtr baseObjPtr = Marshal.GetIUnknownForObject(windowXamlSource);
        try
        {
            return (IDesktopWindowXamlSourceNative)Marshal.GetTypedObjectForIUnknown(baseObjPtr, typeof(IDesktopWindowXamlSourceNative));
        }
        finally
        {
            Marshal.Release(baseObjPtr);
        }
    }

    public static IDesktopWindowXamlSourceNative2 GetNative2(this DesktopWindowXamlSource windowXamlSource)
    {
        IntPtr baseObjPtr = Marshal.GetIUnknownForObject(windowXamlSource);
        try
        {
            return (IDesktopWindowXamlSourceNative2)Marshal.GetTypedObjectForIUnknown(baseObjPtr, typeof(IDesktopWindowXamlSourceNative2));
        }
        finally
        {
            Marshal.Release(baseObjPtr);
        }
    }
}
