using System.Runtime.InteropServices;

namespace MinecraftXinYi.Windows.ModernUI.Core;

using MetaData;

/// <summary>
/// 为 Win32 窗口提供高 DPI 缩放支持
/// </summary>
public static class HighDPISupport
{
    public static class NativeInterop
    {
        public const nint DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2 = -4;
        public const nint DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2_RET = 34;

        [DllImport(Win32UIAPISetName.ExtMsWinRTCoreNtUserDPIL120, ExactSpelling = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static extern nint SetThreadDpiAwarenessContext(nint dpiContext);

        [DllImport(Win32UIAPISetName.ExtMsWinRTCoreNtUserDPIL120, ExactSpelling = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static extern nint GetThreadDpiAwarenessContext();

        [DllImport(Win32UIAPISetName.ExtMsWinNtUserWindowL115, ExactSpelling = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static extern uint GetDpiForWindow(nint hwnd);
    }

    public static void EnableModernHighDPIScalingForThread()
        => NativeInterop.SetThreadDpiAwarenessContext(NativeInterop.DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2);

    public static bool IsModernHighDPIScalingEnabledForThread()
        => NativeInterop.GetThreadDpiAwarenessContext() == NativeInterop.DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2_RET;
}
