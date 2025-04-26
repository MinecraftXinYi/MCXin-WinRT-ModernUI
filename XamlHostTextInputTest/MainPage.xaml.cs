using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace XamlHostTextInputTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a <see cref="Frame">.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            Background = new AcrylicBrush() { BackgroundSource = AcrylicBackgroundSource.HostBackdrop, TintLuminosityOpacity = 0 };
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ((Button)sender).Content = "Clicked";
        }
    }
}
