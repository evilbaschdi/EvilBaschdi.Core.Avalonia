using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Styling;

namespace EvilBaschdi.Core.Avalonia.Controls;

/// <inheritdoc />
public partial class SplashWindow : Window
{
    /// <summary />
    /// <inheritdoc />
    public SplashWindow(string splashTitle)
    {
        InitializeComponent();

        var isDark = Application.Current?.ActualThemeVariant == ThemeVariant.Dark;

        var baseDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "about.png");
        var assetsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "about.png");
        var logoSourcePath = File.Exists(baseDirectory) ? baseDirectory : assetsDirectory;

        SplashImage.Source = new Bitmap(logoSourcePath);

        SplashBorder.Background = new SolidColorBrush(isDark
            ? Color.Parse("#202020")
            : Color.Parse("#FFFFFF"));

        TaglineText.Text = splashTitle;
        TaglineText.Foreground = isDark ? Brushes.White : Brushes.Black;
    }
}