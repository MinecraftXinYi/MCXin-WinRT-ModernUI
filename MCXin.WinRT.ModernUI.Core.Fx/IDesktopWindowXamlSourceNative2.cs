using System;
using System.Runtime.InteropServices;

namespace MinecraftXinYi.Windows.ModernUI.Core;

using MetaData;

/// <summary>
/// 提供一种方法，使 WinRT XAML 框架能够处理承载 WinRT XAML 控件的 DesktopWindowXamlSource 对象的 Windows 消息。
/// IDesktopWindowXamlSourceNative2 接口继承自 IDesktopWindowXamlSourceNative 接口。
/// </summary>
[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(WinRTUICoreInterfaceGuid.IDesktopWindowXamlSourceNative2)]
public partial interface IDesktopWindowXamlSourceNative2 : IDesktopWindowXamlSourceNative
{
    /// <summary>
    /// 将当前 IDesktopWindowXamlSourceNative 实例附加到桌面应用中与窗口句柄关联的父 UI 元素。
    /// </summary>
    /// <param name="parentWnd">要在其中托管 WinRT XAML 控件的父 UI 元素的窗口句柄。</param>
    /// <exception cref="COMException" />
    public new void AttachToWindow(nint parentWnd);

    /// <summary>
    /// 获取与当前 IDesktopWindowXamlSourceNative 实例关联的父 UI 元素的窗口句柄。
    /// </summary>
    /// <returns>与当前 IDesktopWindowXamlSourceNative 实例关联的父 UI 元素的窗口句柄。</returns>
    /// <exception cref="COMException" />
    public new nint GetWindowHandle();

    /// <summary>
    /// 使 WinRT XAML 框架能够处理托管 WinRT XAML 控件的 DesktopWindowXamlSource 对象的 Windows 消息。
    /// </summary>
    /// <param name="message">要处理的 Windows 消息。</param>
    /// <returns>如果消息已处理，则为 True;否则为 false。</returns>
    /// <exception cref="COMException" />
    [return: MarshalAs(UnmanagedType.Bool)]
    public unsafe bool PreTranslateMessage(void* message);
}
