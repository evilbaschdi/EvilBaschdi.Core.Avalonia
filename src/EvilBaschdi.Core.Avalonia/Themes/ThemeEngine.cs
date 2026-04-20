using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using EvilBaschdi.Core.Extensions;
using FluentAvalonia.UI.Windowing;

namespace EvilBaschdi.Core.Avalonia.Themes;

/// <summary>
///     Engine to initialize and manage application themes.
/// </summary>
public static class ThemeEngine
{
    private static readonly PlatformThemeColorProvider ThemeColorProvider = new();

    /// <summary>
    ///     Initializes the theme resources based on the current platform.
    /// </summary>
    /// <param name="app">The Avalonia application instance.</param>
    public static void Initialize(Application app)
    {
        var (accent, background) = ThemeColorProvider.GetSystemColors();

        app.Resources["AccentBrush"] = new SolidColorBrush(accent);
        app.Resources["BackgroundBrush"] = new SolidColorBrush(background);
    }

    /// <summary>
    ///     Sets platform-specific visual effects for the window.
    /// </summary>
    /// <returns></returns>
    public static EventHandler SetPlatformSpecificVisualEffects()
    {
        return (sender, _) =>
               {
                   if (sender is not Window window)
                   {
                       return;
                   }

                   if (VersionHelper.IsWindows)
                   {
                       window.TransparencyLevelHint =
                       [
                           WindowTransparencyLevel.Mica,
                           WindowTransparencyLevel.AcrylicBlur,
                           WindowTransparencyLevel.Blur,
                           WindowTransparencyLevel.Transparent
                       ];

                       if (VersionHelper.IsWindows11)
                       {
                           window.Background = Brushes.Transparent;
                       }
                   }
                   else
                   {
                       window.Background = (IBrush)Application.Current!.Resources["BackgroundBrush"];
                   }
               };
    }

    /// <summary>
    ///     Sets the window margin based on the provided parameters.
    /// </summary>
    /// <param name="window"></param>
    /// <param name="resizeWithBorder400"></param>
    public static void SetWindowSize(Window window, bool resizeWithBorder400)
    {
        window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        // ReSharper disable once InvertIf
        if (resizeWithBorder400 && window.Screens.Primary != null)
        {
            window.Width = window.Screens.Primary.WorkingArea.Width - 400;
            window.Height = window.Screens.Primary.WorkingArea.Height - 400;
        }
    }

    /// <summary>
    ///     Handles OS-dependent title bar adjustments for the given window.
    /// </summary>
    /// <param name="window"></param>
    public static void HandleOsDependentTitleBar(Window window)
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

        var (_, background) = ThemeColorProvider.GetSystemColors();
        appWindow.Background = new SolidColorBrush(background);

        var titleBarPanel = appWindow.FindNameScope()?.Find<Panel>("TitleBarPanel");
        var mainPanel = appWindow.FindNameScope()?.Find<Panel>("MainPanel");
        titleBarPanel?.IsVisible = false;
        mainPanel?.Margin = new Thickness(0, 0, 0, 0);
    }

    /// <summary>
    ///     Applies the theme to the specified window, including visual effects, size adjustments, and title bar handling.
    /// </summary>
    /// <param name="window"></param>
    /// <param name="resizeWithBorder400"></param>
    public static void ApplyThemeToWindow(Window window, bool resizeWithBorder400)
    {
        ArgumentNullException.ThrowIfNull(window);
        window.Opened += SetPlatformSpecificVisualEffects();
        SetWindowSize(window, resizeWithBorder400);
        HandleOsDependentTitleBar(window);
    }
}