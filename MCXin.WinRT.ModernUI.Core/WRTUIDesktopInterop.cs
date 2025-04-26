#if NET8_0_OR_GREATER
using WinRT;
#else
using System;
using System.Runtime.InteropServices;
#endif

namespace MinecraftXinYi.Windows.ModernUI.Core;

public static partial class WRTUIDesktopInterop
{
    public static IInitializeWithWindow GetInitializer(object winrtUIObject)
    {
#if NET8_0_OR_GREATER
        return winrtUIObject.As<IInitializeWithWindow>();
#else
        IntPtr baseObjPtr = Marshal.GetIUnknownForObject(winrtUIObject);
        try
        {
            return (IInitializeWithWindow)Marshal.GetTypedObjectForIUnknown(baseObjPtr, typeof(IInitializeWithWindow));
        }
        finally
        {
            Marshal.Release(baseObjPtr);
        }
#endif
    }
}
