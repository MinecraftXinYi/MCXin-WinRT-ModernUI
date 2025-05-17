using System.Threading.Tasks;
using System.Threading;
using System;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;
using Windows.Win32.Graphics.Gdi;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;
using WinRT;

namespace MinecraftXinYi.Windows.ModernUI;

using Core;
using System.Diagnostics;

/// <summary>
/// Represents a system-managed container for the content of an app.
/// </summary>
public partial class DesktopWindow
{
    private readonly DesktopWindowXamlSource windowXamlSource = new();
    private IDesktopWindowXamlSourceNative2 windowXamlSourceNative;

    private readonly HWND windowHandle;
    private readonly WNDCLASSEXW windowClassEx;
    private bool windowIsClosed = false;

    private unsafe void InitWindowXamlSourceNative()
    {
        windowXamlSourceNative = windowXamlSource.As<IDesktopWindowXamlSourceNative2>();
        windowXamlSourceNative.AttachToWindow(windowHandle);
        ResizeWindowToDesktopWindowXamlSourceWindowDimensions();
    }

    private void ResizeWindowToDesktopWindowXamlSourceWindowDimensions()
    {
        if (windowIsClosed) return;
        _ = PInvoke.GetClientRect(windowHandle, out RECT rect);
        _ = PInvoke.SetWindowPos(
            new(windowXamlSourceNative.GetWindowHandle()),
            new(),
            0, 0,
            rect.Width, rect.Height,
            SET_WINDOW_POS_FLAGS.SWP_NOACTIVATE | SET_WINDOW_POS_FLAGS.SWP_NOZORDER | SET_WINDOW_POS_FLAGS.SWP_SHOWWINDOW);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DesktopWindow"/> class.
    /// </summary>
    public DesktopWindow()
    {
        windowClassEx = RegisterDesktopWindowClass(WNDPROC);
        windowHandle = CreateDesktopWindow();
        InitWindowXamlSourceNative();
    }

    /// <summary>
    /// Get the handle of the window.
    /// </summary>
    public nint Handle => windowHandle;

    private void InitDispatcher()
    {
        Dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;
    }

    /// <summary>
    /// Gets the event dispatcher for the window.
    /// </summary>
    public CoreDispatcher Dispatcher { get; private set; }

    /// <summary>
    /// Gets or sets the visual root of an application window.
    /// </summary>
    public UIElement Content
    {
        get => windowXamlSource.Content;
        set => windowXamlSource.Content = value;
    }

    /// <summary>
    /// Gets or sets the XamlRoot in which this element is being viewed.
    /// </summary>
    public XamlRoot XamlRoot
    {
        get => windowXamlSource.Content.XamlRoot;
        set => windowXamlSource.Content.XamlRoot = value;
    }

    /// <summary>
    /// Gets or sets a string used for the window title.
    /// </summary>
    public unsafe string Title
    {
        get
        {
            int windowTextLength = PInvoke.GetWindowTextLength(windowHandle);
            char* windowText = stackalloc char[windowTextLength + 1];
            _ = PInvoke.GetWindowText(windowHandle, windowText, windowTextLength + 1);
            return new string(windowText);
        }
        set => _ = PInvoke.SetWindowText(windowHandle, value);
    }

    /// <summary>
    /// Occurs when the window has closed.
    /// </summary>
    public event TypedEventHandler<DesktopWindow, object> Closed;

    /// <summary>
    /// Shows the window and activates it.
    /// </summary>
    public void Show() => _ = PInvoke.ShowWindow(windowHandle, SHOW_WINDOW_CMD.SW_NORMAL);

    /// <summary>
    /// Sets the icon for the window, using the specified icon path.
    /// </summary>
    /// <param name="iconPath">The path of the icon.</param>
    public unsafe void SetIcon(string iconPath)
    {
        fixed (char* ptr = iconPath)
        {
            HANDLE icon = PInvoke.LoadImage(new HINSTANCE(), ptr, GDI_IMAGE_TYPE.IMAGE_ICON, 0, 0, IMAGE_FLAGS.LR_LOADFROMFILE);
            _ = PInvoke.SendMessage(windowHandle, PInvoke.WM_SETICON, PInvoke.ICON_BIG, new LPARAM((nint)icon.Value));
        }
    }

    private unsafe LRESULT WNDPROC(HWND hWnd, uint message, WPARAM wParam, LPARAM lParam)
    {
        switch (message)
        {
            case PInvoke.WM_PAINT:
                HDC hdc = PInvoke.BeginPaint(hWnd, out PAINTSTRUCT ps);
                _ = PInvoke.GetClientRect(hWnd, out RECT rect);
                _ = PInvoke.FillRect(hdc, &rect, (HBRUSH)(void*)PInvoke.GetStockObject(GET_STOCK_OBJECT_FLAGS.WHITE_BRUSH));
                _ = PInvoke.EndPaint(hWnd, ps);
                return new LRESULT();
            case PInvoke.WM_CLOSE when windowIsClosed:
                goto default;
            case PInvoke.WM_CLOSE:
                windowIsClosed = true;
                Closed?.Invoke(this, null!);
                goto default;
            case PInvoke.WM_SIZE:
                Debug.WriteLine(HighDPISupport.GetWindowDpi(hWnd));
                ResizeWindowToDesktopWindowXamlSourceWindowDimensions();
                return new LRESULT();
            case PInvoke.WM_CREATE:
                return new LRESULT();
            case PInvoke.WM_DESTROY:
                PInvoke.PostQuitMessage(0);
                return new LRESULT();
            default:
                return PInvoke.DefWindowProc(hWnd, message, wParam, lParam);
        }
    }

}

public partial class DesktopWindow
{
    /// <summary>
    /// Create a new <see cref="DesktopWindow"/> instance.
    /// </summary>
    /// <returns>The new instance of <see cref="DesktopWindow"/>.</returns>
    public unsafe static Task<DesktopWindow> CreateAsync()
    {
        TaskCompletionSource<DesktopWindow> taskCompletionSource = new();

        new Thread(() =>
        {
            try
            {
                Debug.WriteLine(HighDPISupport.EnableModernHighDPIScalingForThread());
                DesktopWindow window = new();

                taskCompletionSource.SetResult(window);

                MSG msg = new();
                while (msg.message != PInvoke.WM_QUIT)
                {
                    Thread.Sleep(1);
                    if (PInvoke.PeekMessage(out msg, new HWND(), 0, 0, PEEK_MESSAGE_REMOVE_TYPE.PM_REMOVE))
                    {
                        window.windowXamlSourceNative?.PreTranslateMessage(&msg);
                        _ = PInvoke.DispatchMessage(msg);
                    }
                }
            }
            catch (Exception e)
            {
                taskCompletionSource.SetException(e);
            }
        })
        {
            Name = nameof(DesktopWindowXamlSource)
        }.Start();

        return taskCompletionSource.Task;
    }
}
