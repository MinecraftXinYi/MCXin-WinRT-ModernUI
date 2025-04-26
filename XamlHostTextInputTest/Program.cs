using System.Threading.Tasks;
using WinAppModelHelpers;
using Windows.UI.Xaml.Hosting;
using WinRT;
using MinecraftXinYi.Windows.ModernUI;
using System;

namespace XamlHostTextInputTest;

public static class Program
{
    [STAThread]
    static async Task Main(string[] args)
    {
        ComWrappersSupport.InitializeComWrappers();
        App app = new(false);
        WindowsXamlManager xamlManager = WindowsXamlManager.InitializeForCurrentThread();
        DesktopWindow desktopWindow = await DesktopWindow.CreateAsync();
        desktopWindow.Content = new MainPage();
        desktopWindow.Show();
        return;
    }
}
