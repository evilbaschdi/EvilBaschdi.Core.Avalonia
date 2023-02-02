using Avalonia.Controls;

namespace EvilBaschdi.Core.Avalonia;

/// <inheritdoc />
public class WindowInstance : IWindowInstance
{
    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="window"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public WindowInstance(Window window)
    {
        Value = window ?? throw new ArgumentNullException(nameof(window));
    }

    /// <inheritdoc />
    public Window Value { get; }
}