using EvilBaschdi.Core.Avalonia.DummyAppMvvm.Models;
using EvilBaschdi.Core.Avalonia.DummyAppMvvm.ViewModels;
using EvilBaschdi.Core.Avalonia.DummyAppMvvm.ViewModels.Internal;
using EvilBaschdi.Core.Avalonia.DummyAppMvvm.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace EvilBaschdi.Core.Avalonia.DummyAppMvvm.DependencyInjection;

/// <summary />
public static class ConfigureDummyAppMvvmServiceCollection
{
    /// <summary />
    public static void AddDummyAppMvvmServiceCollection(this IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddSingleton<IHandleOsDependentTitleBar, HandleOsDependentTitleBar>();
        serviceCollection.TryAddSingleton<IApplicationLayout, ApplicationLayout>();
        serviceCollection.TryAddSingleton<IMainWindowByApplicationLifetime, MainWindowByApplicationLifetime>();

        serviceCollection.AddSingleton<MainWindowViewModel>();
        serviceCollection.AddSingleton<ExtendedInformationViewModel>();
        serviceCollection.AddTransient<ExtendedInformation>();
        serviceCollection.AddSingleton<IConfigureDataGridCollectionView, ConfigureDataGridCollectionView>();
        serviceCollection.AddSingleton<ICurrentItem, CurrentItem>();
        serviceCollection.AddSingleton<IShowExtendedInformation, ShowExtendedInformation>();
    }
}