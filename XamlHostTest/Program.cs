using System.Threading.Tasks;
using WinAppModelHelpers;
using Windows.UI.Xaml.Hosting;
using WinRT;
using XamlIslandsTest;
using MinecraftXinYi.Windows.ModernUI;

namespace XamlHostTest;

public static class Program
{
    static async Task Main(string[] args)
    {
        if (AppxEnvironment.IsAppx && AppxEnvironment.IsCoreApplication)
        {
            Windows.UI.Xaml.Application.Start((p) =>
            {
                var context = new Windows.System.DispatcherQueueSynchronizationContext(Windows.System.DispatcherQueue.GetForCurrentThread());
                System.Threading.SynchronizationContext.SetSynchronizationContext(context);
                new App(true);
            });
        }
        else
        {
            ComWrappersSupport.InitializeComWrappers();
            App app = new(false);
            DesktopWindow desktopWindow = await DesktopWindow.CreateAsync();
            desktopWindow.Content = new MainPage();
            desktopWindow.Show();
        }
        return;
    }
}
