using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using EvilBaschdi.Core.Extensions;

namespace EvilBaschdi.Core.Avalonia.Behaviors;

/// <summary>
///     Implements platform-specific behavior for window opened events.
/// </summary>
public class WindowOpenedBehavior : IWindowOpenedBehavior
{
    /// <summary>
    ///     Applies platform-specific transparency and visual effects when a window opens.
    /// </summary>
    public void OnWindowOpened(Window window)
    {
        if (VersionHelper.IsWindows)
        {
            window.Background = Brushes.Transparent;
            window.TransparencyLevelHint =
            [
                WindowTransparencyLevel.Mica,
                WindowTransparencyLevel.AcrylicBlur,
                WindowTransparencyLevel.Blur,
                WindowTransparencyLevel.Transparent
            ];
        }
        else
        {
            window.Background = (IBrush)Application.Current!.Resources["BackgroundBrush"];
        }
    }
}