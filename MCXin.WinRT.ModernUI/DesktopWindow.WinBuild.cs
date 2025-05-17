using System.Diagnostics;
using System.Runtime.InteropServices;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;
using Windows.Win32.Graphics.Gdi;

namespace MinecraftXinYi.Windows.ModernUI;

public partial class DesktopWindow
{
    private static readonly unsafe HINSTANCE g_hInstance = new((void*)Process.GetCurrentProcess().Handle);

    private static unsafe WNDCLASSEXW RegisterDesktopWindowClass(WNDPROC lpfnWndProc)
    {
        fixed (char* lps_windowClassName = MWConstantStrings.s_windowClassName)
        {
            if (!PInvoke.GetClassInfoEx(g_hInstance, lps_windowClassName, out WNDCLASSEXW wndClassEx))
            {
                wndClassEx.cbSize = (uint)Marshal.SizeOf(wndClassEx);
                wndClassEx.style = WNDCLASS_STYLES.CS_HREDRAW | WNDCLASS_STYLES.CS_VREDRAW;
                wndClassEx.cbClsExtra = 0;
                wndClassEx.cbWndExtra = 0;
                wndClassEx.hCursor = PInvoke.LoadCursor(new HINSTANCE(), PInvoke.IDC_ARROW);
                wndClassEx.hbrBackground = (HBRUSH)((nint)SYS_COLOR_INDEX.COLOR_WINDOW + 1);
                wndClassEx.hInstance = g_hInstance;
                wndClassEx.lpszClassName = lps_windowClassName;

                wndClassEx.lpfnWndProc = lpfnWndProc;
                _ = PInvoke.RegisterClassEx(wndClassEx);

                return wndClassEx;
            }
            return default;
        }
    }

    private static unsafe HWND CreateDesktopWindow()
    {
        fixed (char* lps_windowClassName = MWConstantStrings.s_windowClassName, lps_defaultWindowTitle = MWConstantStrings.s_defaultWindowTitle)
        {
            return PInvoke.CreateWindowEx(
                0,                                  // Extended Style
                lps_windowClassName,                  // name of window class
                lps_defaultWindowTitle,               // title-bar string
                WINDOW_STYLE.WS_OVERLAPPEDWINDOW | WINDOW_STYLE.WS_VISIBLE,  // top-level window
                int.MinValue,                       // default horizontal position
                (int)SHOW_WINDOW_CMD.SW_HIDE,       // If the y parameter is some other value,
                                                    // then the window manager calls ShowWindow with that value as the nCmdShow parameter
                int.MinValue,                       // default width
                int.MinValue,                       // default height
                new(),                              // no owner window
                new(),                               // use class menu
                g_hInstance,
                null);
        }
    }
}
