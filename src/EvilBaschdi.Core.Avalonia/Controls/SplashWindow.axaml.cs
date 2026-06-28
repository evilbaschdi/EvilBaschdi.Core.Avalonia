using Avalonia.Controls;
using Avalonia.Media.Imaging;
using EvilBaschdi.Core.Avalonia.DependencyInjection;

namespace EvilBaschdi.Core.Avalonia.Controls;

/// <inheritdoc />
public partial class SplashWindow : Window
{
    /// <summary />
    public SplashWindow()
    {
        InitializeComponent();

        var baseDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "about.png");
        var assetsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "about.png");
        var logoSourcePath = File.Exists(baseDirectory) ? baseDirectory : assetsDirectory;

        SplashImage.Source = new Bitmap(logoSourcePath);

        TaglineText.Text = string.IsNullOrWhiteSpace(ApplicationServices.AppName) ? "Starting ..." : ApplicationServices.AppName;
    }
}