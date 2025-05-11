using System.Reactive;

namespace EvilBaschdi.Core.Avalonia.Mvvm.Command;

/// <inheritdoc cref="IRun" />
/// <inheritdoc cref="IInitReactiveCommand{TParam,TResult}" />
public interface IReactiveCommandRun<TParam> : IInitReactiveCommand<TParam, Unit>, IRun;