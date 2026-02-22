using Avalonia;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI.Avalonia.Splat;
using ReactiveUI.Builder;

namespace EvilBaschdi.Core.Avalonia;

/// <inheritdoc />
// ReSharper disable once InconsistentNaming
public class AppBuilderImplementationToUseReactiveUIWithMicrosoftDependencyResolver<TApp> : IAppBuilderImplementationToUseReactiveUIWithMicrosoftDependencyResolver
    where TApp : Application, new()
{
    /// <inheritdoc />
    // ReSharper disable once InconsistentNaming
    public AppBuilder ValueFor(Action<IServiceCollection> containerConfig, Action<IServiceProvider> withResolver, Action<ReactiveUIBuilder> withReactiveUIBuilder = null)
    {
        ArgumentNullException.ThrowIfNull(containerConfig);
        ArgumentNullException.ThrowIfNull(withResolver);

        var win32PlatformOptions = new Win32PlatformOptions();

        return AppBuilder.Configure<TApp>()
                         .UsePlatformDetect()
                         .LogToTrace()
                         .With(win32PlatformOptions)
                         .UseReactiveUIWithMicrosoftDependencyResolver(containerConfig, withResolver, withReactiveUIBuilder);
    }
}