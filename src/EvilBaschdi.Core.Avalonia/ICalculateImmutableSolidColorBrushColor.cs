using FluentAvalonia.UI.Media;

namespace EvilBaschdi.Core.Avalonia;

/// <inheritdoc />
public interface ICalculateImmutableSolidColorBrushColor : IValueFor<(float lightenPercent, Color2 fallBackColor), Color2>
{
}