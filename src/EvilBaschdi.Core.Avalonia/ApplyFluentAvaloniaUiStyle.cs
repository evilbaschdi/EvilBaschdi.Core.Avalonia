using System.Runtime.InteropServices;
using Avalonia.Controls;
using Avalonia.Media;
using EvilBaschdi.Core.Extensions;
using FluentAvalonia.Styling;

namespace EvilBaschdi.Core.Avalonia;

/// <inheritdoc />
public class ApplyFluentAvaloniaUiStyle : IApplyFluentAvaloniaUiStyle
{
    private readonly IOnRequestedThemeChanged _onRequestedThemeChanged;
    private readonly ITryEnableMicaEffect _tryEnableMicaEffect;
    private readonly IWindowInstance _windowInstance;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="windowInstance"></param>
    /// <param name="onRequestedThemeChanged"></param>
    /// <param name="tryEnableMicaEffect"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public ApplyFluentAvaloniaUiStyle(IWindowInstance windowInstance, IOnRequestedThemeChanged onRequestedThemeChanged, ITryEnableMicaEffect tryEnableMicaEffect)
    {
        _windowInstance = windowInstance ?? throw new ArgumentNullException(nameof(windowInstance));
        _onRequestedThemeChanged = onRequestedThemeChanged ?? throw new ArgumentNullException(nameof(onRequestedThemeChanged));
        _tryEnableMicaEffect = tryEnableMicaEffect ?? throw new ArgumentNullException(nameof(tryEnableMicaEffect));
    }

    /// <inheritdoc />
    public void RunFor(FluentAvaloniaTheme fluentAvaloniaTheme)
    {
        if (fluentAvaloniaTheme == null)
        {
            throw new ArgumentNullException(nameof(fluentAvaloniaTheme));
        }

        fluentAvaloniaTheme.RequestedThemeChanged += _onRequestedThemeChanged.RunFor;

        // Enable Mica on Windows 11
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) && VersionHelper.IsWindows11 && fluentAvaloniaTheme.RequestedTheme != FluentAvaloniaTheme.HighContrastModeString)
        {
            _windowInstance.Value.TransparencyBackgroundFallback = Brushes.Transparent;
            _windowInstance.Value.TransparencyLevelHint = WindowTransparencyLevel.Mica;

            _tryEnableMicaEffect.RunFor(fluentAvaloniaTheme);
        }

        fluentAvaloniaTheme.ForceWin32WindowToTheme(_windowInstance.Value);
    }
}