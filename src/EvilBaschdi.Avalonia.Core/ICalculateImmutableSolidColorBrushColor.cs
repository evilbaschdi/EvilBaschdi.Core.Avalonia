using EvilBaschdi.Core;
using FluentAvalonia.UI.Media;

namespace EvilBaschdi.Avalonia.Core;

/// <inheritdoc />
public interface ICalculateImmutableSolidColorBrushColor : IValueFor<(float lightenPercent, Color2 fallBackColor), Color2>
{
}