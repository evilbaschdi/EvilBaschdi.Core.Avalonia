using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;

namespace EvilBaschdi.Core.Avalonia;

/// <inheritdoc />
public class ApplicationLayout : IApplicationLayout
{
    /// <inheritdoc />
    public void RunFor((bool Center, bool ResizeWithBorder400) value)
    {
        if (Application.Current == null)
        {
            return;
        }

        var (center, resizeWithBorder400) = value;
        var mainWindow = Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop ? desktop.MainWindow : null;

        if (mainWindow != null)
        {
            RunFor((mainWindow, center, resizeWithBorder400));
        }
    }

    /// <inheritdoc />
    public void RunFor((Window Window, bool Center, bool ResizeWithBorder400) value)
    {
        var (window, center, resizeWithBorder400) = value;
        if (center)
        {
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        // ReSharper disable once InvertIf
        if (resizeWithBorder400 && window.Screens.Primary != null)
        {
            window.Width = window.Screens.Primary.WorkingArea.Width - 400;
            window.Height = window.Screens.Primary.WorkingArea.Height - 400;
        }
    }
}