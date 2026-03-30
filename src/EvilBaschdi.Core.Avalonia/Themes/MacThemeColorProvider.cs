using Avalonia;
using Avalonia.Media;
using Avalonia.Styling;

namespace EvilBaschdi.Core.Avalonia.Themes;

/// <inheritdoc />
public class MacThemeColorProvider : IThemeColorProvider
{
    /// <inheritdoc />
    public (Color Accent, Color Background) GetSystemColors()
    {
        // macOS default accent (Blue)
        var accent = Color.Parse("#007AFF");
        var background = Color.Parse("#1E1E1E");

        var settings = Application.Current?.PlatformSettings;
        if (settings != null)
        {
            var colorValues = settings.GetColorValues();
            accent = colorValues.AccentColor1;

            background = Application.Current.ActualThemeVariant == ThemeVariant.Dark
                ? Color.Parse("#1E1E1E")
                : Color.Parse("#F6F6F6");
        }

        return (accent, background);
    }
}