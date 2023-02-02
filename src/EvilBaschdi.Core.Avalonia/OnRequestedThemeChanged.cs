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
    public void RunFor(FluentAvaloniaTheme sender, RequestedThemeChangedEventArgs args)
    {
        if (sender == null)
        {
            throw new ArgumentNullException(nameof(sender));
        }

        if (args == null)
        {
            throw new ArgumentNullException(nameof(args));
        }

        if (VersionHelper.IsWindows11 && args.NewTheme != FluentAvaloniaTheme.HighContrastModeString)
        {
            _tryEnableMicaEffect.RunFor(sender);
        }
    }
}