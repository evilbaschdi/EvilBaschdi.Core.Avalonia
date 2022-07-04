using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using EvilBaschdi.Avalonia.DummyAppMvvm.ViewModels;
using EvilBaschdi.Avalonia.DummyAppMvvm.Views;

namespace EvilBaschdi.Avalonia.DummyAppMvvm;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
                                 {
                                     DataContext = new MainWindowViewModel(),
                                 };
        }

        base.OnFrameworkInitializationCompleted();
    }
}