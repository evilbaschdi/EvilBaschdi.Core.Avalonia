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
    public AppBuilder ValueFor(Action<IServiceCollection> containerConfig, Action<ReactiveUIBuilder> withReactiveUIBuilder)
    {
        ArgumentNullException.ThrowIfNull(containerConfig);
        ArgumentNullException.ThrowIfNull(withReactiveUIBuilder);

        var win32PlatformOptions = new Win32PlatformOptions();

        return AppBuilder.Configure<TApp>()
                         .UsePlatformDetect()
                         .LogToTrace()
                         .With(win32PlatformOptions)
                         .UseReactiveUIWithMicrosoftDependencyResolver(containerConfig, ApplicationServices.Initialize, withReactiveUIBuilder);
    }

    /// <inheritdoc />
    public AppBuilder ValueFor(Action<IServiceCollection> containerConfig)
    {
        ArgumentNullException.ThrowIfNull(containerConfig);

        return ValueFor(containerConfig, _ => { });
    }
}