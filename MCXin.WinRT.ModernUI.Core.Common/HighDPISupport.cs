using System.Runtime.InteropServices;

namespace MinecraftXinYi.Windows.ModernUI.Core;

using MetaData;

/// <summary>
/// 提供 Win32 窗口高 DPI 缩放支持
/// </summary>
public static class HighDPISupport
{
    internal static class NativeInterop
    {
        internal const nint DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2 = -4;
        internal const nint DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2_RET = 34;

        [DllImport(Win32UIAPISetName.ExtMsWinRTCoreNtUserDPIL120, ExactSpelling = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern nint SetThreadDpiAwarenessContext(nint dpiContext);

        [DllImport(Win32UIAPISetName.ExtMsWinRTCoreNtUserDPIL120, ExactSpelling = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern nint GetThreadDpiAwarenessContext();

        [DllImport(Win32UIAPISetName.ExtMsWinRTCoreNtUserDPIL120, ExactSpelling = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern uint GetDpiForWindow(nint hwnd);
    }

    /// <summary>
    /// 为当前线程开启 PerMonitorV2 DPI 感知
    /// </summary>
    /// <returns>一个 <see cref="System.Boolean"/> 值，指示操作是否成功。</returns>
    public static bool EnableModernHighDPIScalingForThread()
    {
        if (NativeInterop.GetThreadDpiAwarenessContext() != NativeInterop.DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2_RET)
        {
            NativeInterop.SetThreadDpiAwarenessContext(NativeInterop.DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2);
            return NativeInterop.GetThreadDpiAwarenessContext() == NativeInterop.DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2_RET;
        }
        else
            return true;
    }

    /// <summary>
    /// 返回指定窗口的每英寸点数 (dpi) 值。
    /// </summary>
    /// <param name="hwnd">要获取其相关信息的窗口。</param>
    /// <returns>窗口的 DPI，取决于窗口 DPI_AWARENESS 。</returns>
    public static uint GetWindowDpi(nint hwnd)
        => NativeInterop.GetDpiForWindow(hwnd);
}
