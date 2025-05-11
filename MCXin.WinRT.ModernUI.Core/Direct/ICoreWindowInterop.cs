using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace MinecraftXinYi.Windows.ModernUI.Core.Direct;

using MetaData;

/// <summary>
/// 使应用能够 (与此接口关联的 CoreWindow) 获取窗口的窗口句柄。
/// </summary>
[GeneratedComInterface]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(WinRTUICoreInterfaceGuid.ICoreWindowInterop)]
public partial interface ICoreWindowInterop
{
    /// <summary>
    /// 获取应用的 CoreWindow (HWND) 句柄。
    /// </summary>
    /// <returns>CoreWindow 的窗口句柄。</returns>
    /// <exception cref="COMException" />
    public nint GetWindowHandle();

    /// <summary>
    /// 设置是否已处理到 CoreWindow 的消息。
    /// </summary>
    /// <param name="messageHandled">标志该消息是否已被处理。</param>
    /// <exception cref="COMException" />
    public void SetMessageHandled([MarshalAs(UnmanagedType.Bool)] bool messageHandled);
}
