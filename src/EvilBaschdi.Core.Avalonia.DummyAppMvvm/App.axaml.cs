using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using EvilBaschdi.Core.Avalonia.DummyAppMvvm.ViewModels;
using EvilBaschdi.Core.Avalonia.DummyAppMvvm.Views;
using Microsoft.Extensions.DependencyInjection;

namespace EvilBaschdi.Core.Avalonia.DummyAppMvvm;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    /// <summary>
    ///     ServiceProvider for DependencyInjection
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public static IServiceProvider? ServiceProvider { get; set; }

    public override void OnFrameworkInitializationCompleted()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<IHandleOsDependentTitleBar, HandleOsDependentTitleBar>();
        serviceCollection.AddSingleton<IApplicationLayout, ApplicationLayout>();
        serviceCollection.AddSingleton<MainWindowViewModel>();

        ServiceProvider = serviceCollection.BuildServiceProvider();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var mainWindow = new MainWindow
                             {
                                 DataContext = ServiceProvider.GetRequiredService<MainWindowViewModel>()
                             };
            desktop.MainWindow = mainWindow;
        }

        base.OnFrameworkInitializationCompleted();
    }
}