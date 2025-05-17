using System;
using System.Runtime.InteropServices;

namespace MinecraftXinYi.Windows.ModernUI.Core;

using MetaData;

public static class Win32ImmersiveThemeSupport
{
    public static class NativeInterop
    {
        [DllImport(Win32UIAPISetName.UXTheme, EntryPoint = "#133")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static extern int AllowDarkModeForWindow(IntPtr hWnd, int allow);

        [DllImport(Win32UIAPISetName.UXTheme, EntryPoint = "#104")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static extern void RefreshImmersiveColorPolicyState();

        [DllImport(Win32UIAPISetName.UXTheme, EntryPoint = "#136")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static extern void FlushMenuThemes();
    }
}
