using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using EvilBaschdi.Core.Avalonia.DummyAppMvvm.ViewModels;
using EvilBaschdi.Core.Avalonia.DummyAppMvvm.Views;

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
#if DEBUG

        this.AttachDeveloperTools();
#endif

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var mainWindow = new MainWindow
                             {
                                 DataContext = ApplicationServices.GetRequiredService<MainWindowViewModel>()
                             };
            desktop.MainWindow = mainWindow;
        }

        base.OnFrameworkInitializationCompleted();
    }
}