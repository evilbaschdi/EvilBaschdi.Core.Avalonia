using FluentAvalonia.Styling;

namespace EvilBaschdi.Core.Avalonia;

/// <inheritdoc />
public interface IOnRequestedThemeChanged : IRunFor2<FluentAvaloniaTheme, RequestedThemeChangedEventArgs>
{
}