using System.Runtime.InteropServices;

namespace MinecraftXinYi.Windows.ModernUI.Core;

using MetaData;

public static class Win32ImmersiveThemeSupport
{
    internal static class NativeInterop
    {
        [DllImport(Win32UIAPISetName.UXTheme, EntryPoint = "#133")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern int AllowDarkModeForWindow(nint hWnd, int allow);

        [DllImport(Win32UIAPISetName.UXTheme, EntryPoint = "#104")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern void RefreshImmersiveColorPolicyState();

        [DllImport(Win32UIAPISetName.UXTheme, EntryPoint = "#136")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern void FlushMenuThemes();
    }

    public static void EnableWin32DarkModeForWindow(nint hWnd, bool enable)
    {
        NativeInterop.AllowDarkModeForWindow(hWnd, enable ? 1 : 0);
        NativeInterop.RefreshImmersiveColorPolicyState();
        NativeInterop.FlushMenuThemes();
    }
}
