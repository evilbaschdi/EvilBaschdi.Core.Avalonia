using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media;
using Avalonia.Platform;
using Avalonia.Styling;
using EvilBaschdi.Core.Extensions;

namespace EvilBaschdi.Core.Avalonia;

/// <inheritdoc />
public class HandleOsDependentTitleBar : IHandleOsDependentTitleBar
{
    /// <inheritdoc />
    public void Run()
    {
        if (Application.Current == null)
        {
            return;
        }

        var mainWindow = Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop ? desktop.MainWindow : null;

        if (mainWindow != null)
        {
            RunFor(mainWindow);
        }
    }

    /// <inheritdoc />
    public void RunFor([NotNull] Window window)
    {
        ArgumentNullException.ThrowIfNull(window);

        if (!VersionHelper.IsWindows)
        {
            return;
        }

        var acrylicBorder = window.FindNameScope()?.Find<ExperimentalAcrylicBorder>("AcrylicBorder");
        var headerPanel = window.FindNameScope()?.Find<Panel>("HeaderPanel");
        var mainPanel = window.FindNameScope()?.Find<Panel>("MainPanel");

        if (acrylicBorder != null)
        {
            if (VersionHelper.IsWindows11)
            {
                acrylicBorder.IsVisible = false;
            }
            else
            {
                if (window.ActualThemeVariant == ThemeVariant.Dark)
                {
                    acrylicBorder.Material.TintColor = Colors.Black;
                }
                else if (window.ActualThemeVariant == ThemeVariant.Light)
                {
                    acrylicBorder.Material.TintColor = Colors.White;
                }
            }
        }

        window.ExtendClientAreaToDecorationsHint = true;
        window.ExtendClientAreaChromeHints = ExtendClientAreaChromeHints.Default;

        if (headerPanel != null)
        {
            headerPanel.IsVisible = true;
        }

        if (mainPanel != null)
        {
            mainPanel.Margin = new(0, 30, 0, 0);
        }
    }
}