using ReactiveUI;

namespace EvilBaschdi.Core.Avalonia.Mvvm.Command;

/// <summary>IReactiveCommand</summary>
public interface IReactiveCommand<TParam, TResult>
{
    /// <inheritdoc cref="ReactiveCommand" />
    ReactiveCommand<TParam, TResult> ReactiveCommandValue { get; }
}