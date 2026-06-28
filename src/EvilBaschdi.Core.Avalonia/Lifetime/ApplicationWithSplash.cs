using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Threading;
using EvilBaschdi.Core.Avalonia.Controls;
using EvilBaschdi.Core.Avalonia.Themes;

namespace EvilBaschdi.Core.Avalonia.Lifetime;

/// <summary>
///     Base application class that handles the lifecycle of a main window initialized with a splash screen.
/// </summary>
public abstract class ApplicationWithSplash : Application
{
    /// <summary>
    ///     Creates the main window instance.
    /// </summary>
    /// <returns>The main window.</returns>
    protected abstract Window CreateMainWindow();

    /// <summary>
    ///     Creates the splash screen window.
    ///     Default is a new <see cref="SplashWindow" /> with the application name.
    /// </summary>
    /// <returns>The splash screen window.</returns>
    protected virtual Window CreateSplashScreen() => new SplashWindow();

    /// <summary>
    ///     Gets whether the main window should be resized with border 400.
    ///     Default is true.
    /// </summary>
    protected virtual bool ResizeWithBorder400 => false;

    /// <summary>
    ///     Hook that is run right before creating the main window.
    /// </summary>
    protected virtual void PreMainWindowCreation()
    {
    }

    /// <inheritdoc />
    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            PreMainWindowCreation();

            var splash = CreateSplashScreen();
            splash?.Show();

            Dispatcher.UIThread.Post(() => StartMainWindow(desktop, splash), DispatcherPriority.Background);
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void StartMainWindow(IClassicDesktopStyleApplicationLifetime desktop, Window splash)
    {
        ThemeEngine.Initialize(this);

        var mainWindow = CreateMainWindow();

        ThemeEngine.ApplyThemeToWindow(mainWindow, ResizeWithBorder400);

        desktop.MainWindow = mainWindow;

        if (splash is not null)
        {
            var splashRef = splash;

            void CloseSplashOnce(object s, EventArgs e)
            {
                mainWindow.Opened -= CloseSplashOnce;
                splashRef.Close();
            }

            mainWindow.Opened += CloseSplashOnce;
        }

        mainWindow.Show();
    }
}