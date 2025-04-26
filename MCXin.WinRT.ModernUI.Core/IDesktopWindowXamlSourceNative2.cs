using System;
using System.Runtime.InteropServices;
#if NET8_0_OR_GREATER
using System.Runtime.InteropServices.Marshalling;
#endif

namespace MinecraftXinYi.Windows.ModernUI.Core;

using MetaData;

/// <summary>
/// 提供一种方法，使 WinRT XAML 框架能够处理承载 WinRT XAML 控件的 DesktopWindowXamlSource 对象的 Windows 消息。
/// IDesktopWindowXamlSourceNative2 接口继承自 IDesktopWindowXamlSourceNative 接口。
/// </summary>
#if NET8_0_OR_GREATER
[GeneratedComInterface]
#else
[ComImport]
#endif
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(WRTUICoreInterfaceGuid.IDesktopWindowXamlSourceNative2)]
public partial interface IDesktopWindowXamlSourceNative2 : IDesktopWindowXamlSourceNative
{
    /// <summary>
    /// 使 WinRT XAML 框架能够处理托管 WinRT XAML 控件的 DesktopWindowXamlSource 对象的 Windows 消息。
    /// </summary>
    /// <param name="message">要处理的 Windows 消息。</param>
    /// <returns>如果消息已处理，则为 True;否则为 false。</returns>
    /// <exception cref="COMException" />
    [return: MarshalAs(UnmanagedType.Bool)]
    public unsafe bool PreTranslateMessage(void* message);
}
