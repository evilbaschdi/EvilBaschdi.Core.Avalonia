using Avalonia.Media.Immutable;
using FluentAvalonia.Styling;
using FluentAvalonia.UI.Media;

namespace EvilBaschdi.Avalonia.Core;

/// <inheritdoc />
public class TryEnableMicaEffect : ITryEnableMicaEffect
{
    private readonly ICalculateImmutableSolidColorBrushColor _calculateImmutableSolidColorBrushColor;
    private readonly IWindowInstance _windowInstance;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="windowInstance"></param>
    /// <param name="calculateImmutableSolidColorBrushColor"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public TryEnableMicaEffect(IWindowInstance windowInstance, ICalculateImmutableSolidColorBrushColor calculateImmutableSolidColorBrushColor)
    {
        _windowInstance = windowInstance ?? throw new ArgumentNullException(nameof(windowInstance));
        _calculateImmutableSolidColorBrushColor = calculateImmutableSolidColorBrushColor ?? throw new ArgumentNullException(nameof(calculateImmutableSolidColorBrushColor));
    }

    /// <inheritdoc />
    public void RunFor(FluentAvaloniaTheme fluentAvaloniaTheme)
    {
        if (fluentAvaloniaTheme == null)
        {
            throw new ArgumentNullException(nameof(fluentAvaloniaTheme));
        }

        if (fluentAvaloniaTheme.RequestedTheme == FluentAvaloniaTheme.HighContrastModeString)
        {
            return;
        }

        Color2 color = default;

        if (fluentAvaloniaTheme.RequestedTheme == FluentAvaloniaTheme.DarkModeString)
        {
            color = _calculateImmutableSolidColorBrushColor.ValueFor((-0.8f, new(32, 32, 32)));
        }
        else if (fluentAvaloniaTheme.RequestedTheme == FluentAvaloniaTheme.LightModeString)
        {
            color = _calculateImmutableSolidColorBrushColor.ValueFor((0.5f, new(243, 243, 243)));
        }

        _windowInstance.Value.Background = new ImmutableSolidColorBrush(color, 0.9);
    }
}