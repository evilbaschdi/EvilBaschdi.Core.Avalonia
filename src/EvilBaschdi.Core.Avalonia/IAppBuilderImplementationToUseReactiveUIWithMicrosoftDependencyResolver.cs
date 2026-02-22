using Avalonia;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI.Builder;

namespace EvilBaschdi.Core.Avalonia;

/// <summary>
///     Provides an AppBuilder configuration entry that integrates ReactiveUI and exposes
///     an API to configure a Microsoft dependency injection container and resolver.
///     Use <see cref="ValueFor(Action{IServiceCollection}, Action{ReactiveUIBuilder})" />
///     to supply service registrations, apply the resolved <see cref="IServiceProvider" /> as the
///     application's resolver, and optionally configure ReactiveUI-specific settings.
/// </summary>
// ReSharper disable once InconsistentNaming
public interface IAppBuilderImplementationToUseReactiveUIWithMicrosoftDependencyResolver
{
    // ReSharper disable once InconsistentNaming

    /// <summary>
    ///     Configure an <see cref="AppBuilder" /> to use Microsoft.Extensions.DependencyInjection
    ///     as the dependency resolver and to wire up ReactiveUI.
    /// </summary>
    /// <param name="containerConfig">
    ///     Action invoked with an <see cref="IServiceCollection" /> to register application services.
    /// </param>
    /// <param name="withReactiveUIBuilder">
    ///     Optional action to configure the <see cref="ReactiveUIBuilder" /> for ReactiveUI-specific setup.
    /// </param>
    /// <returns>
    ///     The configured <see cref="AppBuilder" /> instance.
    /// </returns>
    AppBuilder ValueFor(Action<IServiceCollection> containerConfig, Action<ReactiveUIBuilder> withReactiveUIBuilder = null);
}