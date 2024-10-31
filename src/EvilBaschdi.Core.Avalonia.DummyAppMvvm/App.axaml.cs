using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using EvilBaschdi.Core.Avalonia.DummyAppMvvm.Models;
using EvilBaschdi.Core.Avalonia.DummyAppMvvm.ViewModels;
using EvilBaschdi.Core.Avalonia.DummyAppMvvm.ViewModels.Internal;
using EvilBaschdi.Core.Avalonia.DummyAppMvvm.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace EvilBaschdi.Core.Avalonia.DummyAppMvvm;

/// <inheritdoc />
public class App : Application
{
    /// <summary>
    /// </summary>
    public override void Initialize() => AvaloniaXamlLoader.Load(this);

    /// <summary>
    ///     ServiceProvider for DependencyInjection
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public static IServiceProvider ServiceProvider { get; set; }

    /// <summary>
    /// </summary>
    public override void OnFrameworkInitializationCompleted()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.TryAddSingleton<IHandleOsDependentTitleBar, HandleOsDependentTitleBar>();
        serviceCollection.TryAddSingleton<IApplicationLayout, ApplicationLayout>();
        serviceCollection.TryAddSingleton<IMainWindowByApplicationLifetime, MainWindowByApplicationLifetime>();

        serviceCollection.AddSingleton<MainWindowViewModel>();
        serviceCollection.AddSingleton<ExtendedInformationViewModel>();
        serviceCollection.AddTransient(typeof(ExtendedInformation));
        serviceCollection.AddSingleton<IConfigureDataGridCollectionView, ConfigureDataGridCollectionView>();
        serviceCollection.AddSingleton<ICurrentItem, CurrentItem>();
        serviceCollection.AddSingleton<IShowExtendedInformation, ShowExtendedInformation>();

        ServiceProvider = serviceCollection.BuildServiceProvider();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Line below is needed to remove Avalonia data validation.
            // Without this line you will get duplicate validations from both Avalonia and CT
            BindingPlugins.DataValidators.RemoveAt(0);
            var mainWindow = new MainWindow
                             {
                                 DataContext = ServiceProvider.GetRequiredService<MainWindowViewModel>()
                             };
            desktop.MainWindow = mainWindow;
        }

        base.OnFrameworkInitializationCompleted();
    }
}