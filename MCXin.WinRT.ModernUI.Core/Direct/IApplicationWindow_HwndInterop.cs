using System;
using System.Runtime.InteropServices;
#if NET8_0_OR_GREATER
using System.Runtime.InteropServices.Marshalling;
#endif
using Windows.UI;

namespace MinecraftXinYi.Windows.ModernUI.Core.Direct;

using MetaData;

#if NET8_0_OR_GREATER
[GeneratedComInterface]
#else
[ComImport]
#endif
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(WRTUICoreInterfaceGuid2.IApplicationWindow_HwndInterop)]
public partial interface IApplicationWindow_HwndInterop
{
    public WindowId GetWindowHandle();
}
