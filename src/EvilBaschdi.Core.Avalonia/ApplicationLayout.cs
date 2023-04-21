using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;

namespace EvilBaschdi.Core.Avalonia;

/// <inheritdoc />
public class ApplicationLayout : IApplicationLayout
{
    private readonly bool _center;
    private readonly bool _resizeWithBorder400;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="center"></param>
    /// <param name="resizeWithBorder400"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public ApplicationLayout(bool center = false, bool resizeWithBorder400 = false)
    {
        _center = center;
        _resizeWithBorder400 = resizeWithBorder400;
    }

    /// <inheritdoc />
    public void Run()
    {
        if (Application.Current == null)
        {
            return;
        }

        var mainWindow = Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop ? desktop.MainWindow : null;
        if (mainWindow == null)
        {
            return;
        }

        if (_center)
        {
            mainWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        // ReSharper disable once InvertIf
        if (_resizeWithBorder400)
        {
            if (mainWindow.Screens.Primary != null)
            {
                mainWindow.Width = mainWindow.Screens.Primary.WorkingArea.Width - 400;
                mainWindow.Height = mainWindow.Screens.Primary.WorkingArea.Height - 400;
            }
        }
    }
}