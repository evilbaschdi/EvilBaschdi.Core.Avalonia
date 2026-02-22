using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using EvilBaschdi.Core.Avalonia.DummyAppMvvm.ViewModels;
using EvilBaschdi.Core.Avalonia.DummyAppMvvm.Views;
using Microsoft.Extensions.DependencyInjection;

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
            // Line below is needed to remove Avalonia data validation.
            // Without this line you will get duplicate validations from both Avalonia and CT
            BindingPlugins.DataValidators.RemoveAt(0);
            var mainWindow = new MainWindow
                             {
                                 DataContext = Program.ServiceProvider.GetRequiredService<MainWindowViewModel>()
                             };
            desktop.MainWindow = mainWindow;
        }

        base.OnFrameworkInitializationCompleted();
    }
}