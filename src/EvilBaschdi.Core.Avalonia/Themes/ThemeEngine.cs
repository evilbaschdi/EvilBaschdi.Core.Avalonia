using Avalonia;
using Avalonia.Media;

namespace EvilBaschdi.Core.Avalonia.Themes;

/// <summary>
///     Engine to initialize and manage application themes.
/// </summary>
public static class ThemeEngine
{
    /// <summary>
    ///     Initializes the theme resources based on the current platform.
    /// </summary>
    /// <param name="app">The Avalonia application instance.</param>
    public static void Initialize(Application app)
    {
        var provider = new PlatformThemeColorProvider();
        var (accent, background) = provider.GetSystemColors();

        app.Resources["AccentBrush"] = new SolidColorBrush(accent);
        app.Resources["BackgroundBrush"] = new SolidColorBrush(background);
    }
}