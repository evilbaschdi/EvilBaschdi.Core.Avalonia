namespace EvilBaschdi.Core.Avalonia.Mvvm.Command;

/// <inheritdoc cref="IRun" />
/// <inheritdoc cref="IReactiveCommand{TParam,TResult}" />
public interface IReactiveCommandRun<TParam, TResult> : IReactiveCommand<TParam, TResult>, IRun;