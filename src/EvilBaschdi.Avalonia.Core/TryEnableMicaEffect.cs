using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Immutable;
using FluentAvalonia.Styling;
using FluentAvalonia.UI.Media;

namespace EvilBaschdi.Avalonia.Core;

/// <inheritdoc />
public class TryEnableMicaEffect : ITryEnableMicaEffect
{
    private readonly IWindowInstance _windowInstance;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="windowInstance"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public TryEnableMicaEffect(IWindowInstance windowInstance)
    {
        _windowInstance = windowInstance ?? throw new ArgumentNullException(nameof(windowInstance));
    }

    /// <inheritdoc />
    public void RunFor(FluentAvaloniaTheme fluentAvaloniaTheme)
    {
        if (fluentAvaloniaTheme == null)
        {
            throw new ArgumentNullException(nameof(fluentAvaloniaTheme));
        }

        // The background colors for the Mica brush are still based around SolidBackgroundFillColorBase resource
        // BUT since we can't control the actual Mica brush color, we have to use the window background to create
        // the same effect. However, we can't use SolidBackgroundFillColorBase directly since its opaque, and if
        // we set the opacity the color become lighter than we want. So we take the normal color, darken it and 
        // apply the opacity until we get the roughly the correct color
        // NOTE that the effect still doesn't look right, but it suffices. Ideally we need access to the Mica
        // CompositionBrush to properly change the color but I don't know if we can do that or not
        if (fluentAvaloniaTheme.RequestedTheme == FluentAvaloniaTheme.DarkModeString)
        {
            var color = _windowInstance.Value.TryFindResource("SolidBackgroundFillColorBase", out var value) && value != null
                ? (Color2)(Color)value
                : new(32, 32, 32);

            color = color.LightenPercent(-0.8f);

            _windowInstance.Value.Background = new ImmutableSolidColorBrush(color, 0.78);
        }
        else if (fluentAvaloniaTheme.RequestedTheme == FluentAvaloniaTheme.LightModeString)
        {
            // Similar effect here
            var color = _windowInstance.Value.TryFindResource("SolidBackgroundFillColorBase", out var value) && value != null
                ? (Color2)(Color)value
                : new(243, 243, 243);

            color = color.LightenPercent(0.5f);

            _windowInstance.Value.Background = new ImmutableSolidColorBrush(color, 0.9);
        }
    }
}