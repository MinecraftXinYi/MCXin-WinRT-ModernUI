using System.Threading.Tasks;
using WinAppModelHelpers;
using Windows.UI.Xaml.Hosting;
using WinRT;
using XamlIslandsTest;
using MinecraftXinYi.Windows.ModernUI;

namespace XamlIslandsTestProg;

public static class Program
{
    static async Task Main(string[] args)
    {
        if (AppxEnvironment.IsAppx && AppxEnvironment.IsCoreApplication)
        {
            global::Windows.UI.Xaml.Application.Start((p) =>
            {
                var context = new global::Windows.System.DispatcherQueueSynchronizationContext(global::Windows.System.DispatcherQueue.GetForCurrentThread());
                global::System.Threading.SynchronizationContext.SetSynchronizationContext(context);
                new App(true);
            });
        }
        else
        {
            ComWrappersSupport.InitializeComWrappers();
            App app = new(false);
            WindowsXamlManager xamlManager = WindowsXamlManager.InitializeForCurrentThread();
            DesktopWindow desktopWindow = await DesktopWindow.CreateAsync();
            desktopWindow.Content = new MainPage();
            desktopWindow.Show();
        }
        return;
    }
}
