using Avalonia.Controls;

namespace EvilBaschdi.Core.Avalonia.Behaviors;

/// <summary>
///     Handles operations that should be performed when a window opens.
/// </summary>
public interface IWindowOpenedBehavior
{
    /// <summary>
    ///     Executes when a window has opened.
    /// </summary>
    /// <param name="window">The window that has opened.</param>
    void OnWindowOpened(Window window);
}