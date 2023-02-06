using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Styling;
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
    public void RunFor(ThemeVariant themeVariant)
    {
        if (themeVariant == null)
        {
            throw new ArgumentNullException(nameof(themeVariant));
        }

        if (Application.Current != null)
        {
            Application.Current.ActualThemeVariantChanged += _onRequestedThemeChanged.RunFor;
        }

        // Enable Mica on Windows 11
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) && themeVariant != FluentAvaloniaTheme.HighContrastTheme && VersionHelper.IsWindows11)
        {
            _windowInstance.Value.TransparencyBackgroundFallback = Brushes.Transparent;
            _windowInstance.Value.TransparencyLevelHint = WindowTransparencyLevel.Mica;

            _tryEnableMicaEffect.RunFor(themeVariant);
        }

        //themeVariant.ForceWin32WindowToTheme(_windowInstance.Value);
    }
}