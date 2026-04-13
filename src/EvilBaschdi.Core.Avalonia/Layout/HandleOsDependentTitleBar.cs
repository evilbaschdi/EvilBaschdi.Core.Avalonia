using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media;
using EvilBaschdi.Core.Avalonia.Themes;
using EvilBaschdi.Core.Extensions;
using FluentAvalonia.UI.Windowing;

namespace EvilBaschdi.Core.Avalonia.Layout;

/// <inheritdoc />
public class HandleOsDependentTitleBar : IHandleOsDependentTitleBar
{
    private readonly PlatformThemeColorProvider _themeColorProvider = new();

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
        if (window is not FAAppWindow appWindow)
        {
            return;
        }

        appWindow.TitleBar.ExtendsContentIntoTitleBar = true;

        if (VersionHelper.IsWindows)
        {
            return;
        }

        var (_, background) = _themeColorProvider.GetSystemColors();
        appWindow.Background = new SolidColorBrush(background);

        var titleBarPanel = appWindow.FindNameScope()?.Find<Panel>("TitleBarPanel");
        var mainPanel = appWindow.FindNameScope()?.Find<Panel>("MainPanel");
        titleBarPanel?.IsVisible = false;
        mainPanel?.Margin = new Thickness(0, 0, 0, 0);
    }
}