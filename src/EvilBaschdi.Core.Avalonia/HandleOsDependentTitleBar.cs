using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media;
using Avalonia.Media.Immutable;
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

        window.TransparencyLevelHint = [WindowTransparencyLevel.Mica];
        window.Background = null;

        //topLevel.TransparencyLevelHint = [transparencyLevel];

        if (window.ActualTransparencyLevel != WindowTransparencyLevel.None &&
            window.ActualTransparencyLevel == WindowTransparencyLevel.Mica)
        {
            var transparentBrush = new ImmutableSolidColorBrush(Colors.White, 0);
            window.Background = transparentBrush;
        }

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
                acrylicBorder.IsVisible = true;

                if (window.ActualThemeVariant == ThemeVariant.Dark)
                {
                    acrylicBorder.Material?.TintColor = Colors.Black;
                }
                else if (window.ActualThemeVariant == ThemeVariant.Light)
                {
                    acrylicBorder.Material?.TintColor = Colors.White;
                }
            }
        }

        window.ExtendClientAreaToDecorationsHint = false;

        headerPanel?.IsVisible = true;

        mainPanel?.Margin = new(0, 30, 0, 0);
    }
}