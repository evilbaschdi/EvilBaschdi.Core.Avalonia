using Avalonia;
using Avalonia.Media;
using Avalonia.Styling;

namespace EvilBaschdi.Core.Avalonia.Themes;

/// <inheritdoc />
public class WindowsThemeColorProvider : IThemeColorProvider
{
    /// <inheritdoc />
    public (Color Accent, Color Background) GetSystemColors()
    {
        var accent = Color.Parse("#0078D4");
        var background = Color.Parse("#202020");

        var settings = Application.Current?.PlatformSettings;
        if (settings != null)
        {
            var colorValues = settings.GetColorValues();
            accent = colorValues.AccentColor1;

            background = Application.Current.ActualThemeVariant == ThemeVariant.Dark
                ? Color.Parse("#202020")
                : Color.Parse("#FFFFFF");
        }

        return (accent, background);
    }
}