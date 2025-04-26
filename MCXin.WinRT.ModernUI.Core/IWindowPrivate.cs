using System;
using System.Runtime.InteropServices;
#if NET8_0_OR_GREATER
using System.Runtime.InteropServices.Marshalling;
#endif

namespace MinecraftXinYi.Windows.ModernUI.Core;

using MetaData;

#if NET8_0_OR_GREATER
[GeneratedComInterface]
#else
[ComImport]
#endif
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(WRTUICoreInterfaceGuid.IWindowPrivate)]
public partial interface IWindowPrivate
{
    /// <summary>
    /// 获取一个值，该值指定当前线程上所有 DesktopWindowXamlSource 对象的背景是否透明。
    /// </summary>
    /// <returns>如果窗口背景透明，则为 true ;否则，为 false.</returns>
    [return: MarshalAs(UnmanagedType.Bool)] public bool GetTransparentBackground();

    /// <summary>
    /// 设置一个值，该值指定当前线程上所有 DesktopWindowXamlSource 对象的背景是否透明。
    /// </summary>
    /// <param name="transparentBackground">如果窗口背景透明，则为 true ;否则，为 false.</param>
    public void SetTransparentBackground([MarshalAs(UnmanagedType.Bool)] bool transparentBackground);
}
