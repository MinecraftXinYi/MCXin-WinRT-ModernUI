using System;
using System.Runtime.InteropServices;
using Windows.UI.Xaml;

namespace MinecraftXinYi.Windows.ModernUI.Core;

public static partial class XamlWindowInterop
{
    public static IWindowPrivate GetInterop(this Window window)
    {
        IntPtr baseObjPtr = Marshal.GetIUnknownForObject(window);
        try
        {
            return (IWindowPrivate)Marshal.GetTypedObjectForIUnknown(baseObjPtr, typeof(IWindowPrivate));
        }
        finally
        {
            Marshal.Release(baseObjPtr);
        }
    }
}
