using Avalonia;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI.Builder;

namespace EvilBaschdi.Core.Avalonia.AppBuilderImplementations;

/// <summary>
///     Provides an AppBuilder configuration entry that integrates ReactiveUI and exposes
///     an API to configure a Microsoft dependency injection container and resolver.
/// </summary>
// ReSharper disable once InconsistentNaming
public interface IAppBuilderImplementationToUseReactiveUIWithMicrosoftDependencyResolver : IValueFor<Action<IServiceCollection>, AppBuilder>,
                                                                                           IValueFor2<Action<IServiceCollection>, Action<ReactiveUIBuilder>, AppBuilder>;