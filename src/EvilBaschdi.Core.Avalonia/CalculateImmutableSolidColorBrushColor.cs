using Avalonia.Controls;
using Avalonia.Media;
using FluentAvalonia.UI.Media;

namespace EvilBaschdi.Core.Avalonia;

/// <inheritdoc />
public class CalculateImmutableSolidColorBrushColor : ICalculateImmutableSolidColorBrushColor
{
    private readonly IWindowInstance _windowInstance;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="windowInstance"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public CalculateImmutableSolidColorBrushColor(IWindowInstance windowInstance)
    {
        _windowInstance = windowInstance ?? throw new ArgumentNullException(nameof(windowInstance));
    }

    /// <inheritdoc />
    public Color2 ValueFor((float lightenPercent, Color2 fallBackColor) value)
    {
        // The background colors for the Mica brush are still based around SolidBackgroundFillColorBase resource
        // BUT since we can't control the actual Mica brush color, we have to use the window background to create
        // the same effect. However, we can't use SolidBackgroundFillColorBase directly since its opaque, and if
        // we set the opacity the color become lighter than we want. So we take the normal color, darken it and 
        // apply the opacity until we get the roughly the correct color
        // NOTE that the effect still doesn't look right, but it suffices. Ideally we need access to the Mica
        // CompositionBrush to properly change the color but I don't know if we can do that or not

        var (lightenPercent, fallBackColor) = value;
        var tryFindResource = _windowInstance.Value.TryFindResource("SolidBackgroundFillColorBase", out var solidBackgroundFillColorBase);

        var color = tryFindResource && solidBackgroundFillColorBase != null
            ? (Color2)(Color)solidBackgroundFillColorBase
            : fallBackColor;

        color = color.LightenPercent(lightenPercent);

        return color;
    }
}