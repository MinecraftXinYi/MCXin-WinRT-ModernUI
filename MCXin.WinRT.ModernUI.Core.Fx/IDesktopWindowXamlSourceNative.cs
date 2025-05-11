using System;
using System.Runtime.InteropServices;

namespace MinecraftXinYi.Windows.ModernUI.Core;

using MetaData;

/// <summary>
/// 提供可用于将承载 WinRT XAML 控件的 DesktopWindowXamlSource 对象附加到桌面应用中的父 UI 元素的成员。
/// </summary>
[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(WinRTUICoreInterfaceGuid.IDesktopWindowXamlSourceNative)]
public partial interface IDesktopWindowXamlSourceNative
{
    /// <summary>
    /// 将当前 IDesktopWindowXamlSourceNative 实例附加到桌面应用中与窗口句柄关联的父 UI 元素。
    /// </summary>
    /// <param name="parentWnd">要在其中托管 WinRT XAML 控件的父 UI 元素的窗口句柄。</param>
    /// <exception cref="COMException" />
    public void AttachToWindow(nint parentWnd);

    /// <summary>
    /// 获取与当前 IDesktopWindowXamlSourceNative 实例关联的父 UI 元素的窗口句柄。
    /// </summary>
    /// <returns>与当前 IDesktopWindowXamlSourceNative 实例关联的父 UI 元素的窗口句柄。</returns>
    /// <exception cref="COMException" />
    public nint GetWindowHandle();
}
