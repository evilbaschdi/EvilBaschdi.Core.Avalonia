using Avalonia;
using EvilBaschdi.Core.Avalonia.DummyAppMvvm.DependencyInjection;

namespace EvilBaschdi.Core.Avalonia.DummyAppMvvm;

// ReSharper disable once ClassNeverInstantiated.Global
internal class Program
{
    /// <summary>
    ///     ServiceProvider for DependencyInjection
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public static IServiceProvider ServiceProvider { get; set; }

    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) =>
        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

    // ReSharper disable once MemberCanBePrivate.Global
    public static AppBuilder BuildAvaloniaApp() =>
        new AppBuilderImplementationToUseReactiveUIWithMicrosoftDependencyResolver<App>().ValueFor(
            serviceCollection => { serviceCollection.AddDummyAppMvvmServiceCollection(); },
            sp => ServiceProvider = sp);
}