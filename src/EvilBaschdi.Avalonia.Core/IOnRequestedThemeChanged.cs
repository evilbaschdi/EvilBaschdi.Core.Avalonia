using FluentAvalonia.Styling;

namespace EvilBaschdi.Avalonia.Core;

/// <inheritdoc />
public interface IOnRequestedThemeChanged : IRunFor2<FluentAvaloniaTheme, RequestedThemeChangedEventArgs>
{
}