using System;
using System.Runtime.InteropServices;
#if NET8_0_OR_GREATER
using System.Runtime.InteropServices.Marshalling;
#endif

namespace MinecraftXinYi.Windows.ModernUI.Core;

using MetaData;

/// <summary>
/// 公开一种方法，客户端可通过该方法向桌面应用程序中使用的 Windows 运行时 (WinRT) 对象提供所有者窗口。
/// </summary>
#if NET8_0_OR_GREATER
[GeneratedComInterface]
#else
[ComImport]
#endif
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(WRTUICoreInterfaceGuid.IInitializeWithWindow)]
public partial interface IInitializeWithWindow
{
    /// <summary>
    /// 指定桌面应用中使用的Windows 运行时 (WinRT) 对象要使用的所有者窗口。
    /// </summary>
    /// <param name="hwnd">要用作所有者窗口的窗口的句柄。</param>
    /// <exception cref="COMException" />
    public void Initialize(nint hwnd);
}
