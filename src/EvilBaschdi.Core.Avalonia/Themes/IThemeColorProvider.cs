using Avalonia.Media;

namespace EvilBaschdi.Core.Avalonia.Themes;

/// <summary>
///     Interface for providing system theme colors.
/// </summary>
public interface IThemeColorProvider
{
    /// <summary>
    ///     Gets the system accent and background colors.
    /// </summary>
    /// <returns>A tuple containing the accent and background colors.</returns>
    (Color Accent, Color Background) GetSystemColors();
}