using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using EvilBaschdi.Core.Avalonia.Controls;
using EvilBaschdi.Core.Avalonia.DependencyInjection;
using EvilBaschdi.Core.Avalonia.DummyAppMvvm.ViewModels;
using EvilBaschdi.Core.Avalonia.DummyAppMvvm.Views;
using EvilBaschdi.Core.Avalonia.Themes;

namespace EvilBaschdi.Core.Avalonia.DummyAppMvvm;

/// <inheritdoc />
public class App : Application
{
    /// <summary>
    /// </summary>
    public override void Initialize() => AvaloniaXamlLoader.Load(this);

    /// <summary>
    /// </summary>
    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var splash = new SplashWindow(Current?.Name);
            splash.Show();

            Dispatcher.UIThread.Post(() => StartMainWindow(desktop, splash, MainWindowFunc()), DispatcherPriority.Background);
        }

        base.OnFrameworkInitializationCompleted();
    }

    private static Func<MainWindow> MainWindowFunc()
    {
        return () => new MainWindow
                     {
                         DataContext = ApplicationServices.GetRequiredService<MainWindowViewModel>()
                     };
    }

    private void StartMainWindow(IClassicDesktopStyleApplicationLifetime desktop, SplashWindow splash, Func<MainWindow> mainWindowFunc)
    {
        ThemeEngine.Initialize(this);

        var mainWindow = mainWindowFunc();

        ThemeEngine.ApplyThemeToWindow(mainWindow, true);

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