using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using EvilBaschdi.Core.Avalonia.Themes;

namespace EvilBaschdi.Core.Avalonia.DummyApp;

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
            ThemeEngine.Initialize(this);

            var mainWindow = new MainWindow();

            ThemeEngine.ApplyThemeToWindow(mainWindow, true);

            desktop.MainWindow = mainWindow;
        }

        base.OnFrameworkInitializationCompleted();
    }
}