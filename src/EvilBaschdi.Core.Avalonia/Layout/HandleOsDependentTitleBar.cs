using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media;
using Avalonia.Media.Immutable;
using EvilBaschdi.Core.Avalonia.Themes;
using EvilBaschdi.Core.Extensions;

namespace EvilBaschdi.Core.Avalonia.Layout;

/// <inheritdoc />
public class HandleOsDependentTitleBar : IHandleOsDependentTitleBar
{
    private readonly IThemeColorProvider _themeColorProvider;

    /// <summary>
    ///     Constructor for HandleOsDependentTitleBar.
    /// </summary>
    public HandleOsDependentTitleBar()
    {
        _themeColorProvider = new PlatformThemeColorProvider();
    }

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

        if (window.ActualTransparencyLevel != WindowTransparencyLevel.None &&
            window.ActualTransparencyLevel == WindowTransparencyLevel.Mica)
        {
            var transparentBrush = new ImmutableSolidColorBrush(Colors.White, 0);
            window.Background = transparentBrush;
        }

        if (!VersionHelper.IsWindows)
        {
            var (_, background) = _themeColorProvider.GetSystemColors();
            window.Background = new SolidColorBrush(background);

            return;
        }

        var headerPanel = window.FindNameScope()?.Find<Panel>("HeaderPanel");
        var mainPanel = window.FindNameScope()?.Find<Panel>("MainPanel");

        window.ExtendClientAreaToDecorationsHint = false;

        headerPanel?.IsVisible = true;

        mainPanel?.Margin = new(0, 30, 0, 0);
    }
}