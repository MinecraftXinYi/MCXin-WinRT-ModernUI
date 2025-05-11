using System;

namespace MinecraftXinYi.Windows.ModernUI.Core.MetaData;

/// <summary>
/// 存储实现 UWP Xaml (CoreWindow) Host 所需要的系统条件
/// </summary>
public static class XamlHostRequirements
{
    public static readonly Version
        XHMinSupportedOSVersion = new(10, 0, 17763),
        XHMinStableOSVersion = new(10, 0, 18362);
}
