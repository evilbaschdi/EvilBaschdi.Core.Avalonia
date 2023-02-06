﻿using System.Runtime.InteropServices;
using Avalonia;
using EvilBaschdi.Core.Extensions;
using FluentAvalonia.Styling;

namespace EvilBaschdi.Core.Avalonia;

/// <inheritdoc />
public class OnRequestedThemeChanged : IOnRequestedThemeChanged
{
    private readonly ITryEnableMicaEffect _tryEnableMicaEffect;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="tryEnableMicaEffect"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public OnRequestedThemeChanged(ITryEnableMicaEffect tryEnableMicaEffect)
    {
        _tryEnableMicaEffect = tryEnableMicaEffect ?? throw new ArgumentNullException(nameof(tryEnableMicaEffect));
    }

    /// <inheritdoc />
    public void RunFor(object sender, EventArgs args)
    {
        if (sender == null)
        {
            throw new ArgumentNullException(nameof(sender));
        }

        if (args == null)
        {
            throw new ArgumentNullException(nameof(args));
        }

        var themeVariant = Application.Current?.ActualThemeVariant;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) && themeVariant != FluentAvaloniaTheme.HighContrastTheme)
        {
            if (VersionHelper.IsWindows11)
            {
                _tryEnableMicaEffect.RunFor(themeVariant);
            }
            //_windowInstance.Value.SetValue(_windowInstance.Value.BackgroundProperty, AvaloniaProperty.UnsetValue);
        }
    }
}