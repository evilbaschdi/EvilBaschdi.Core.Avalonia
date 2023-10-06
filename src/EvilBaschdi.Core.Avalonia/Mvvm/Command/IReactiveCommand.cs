using ReactiveUI;

namespace EvilBaschdi.Core.Avalonia.Mvvm.Command;

/// <summary>IReactiveCommand</summary>
public interface IReactiveCommand<TParam, TResult>
{
    /// <inheritdoc cref="ReactiveCommand" />
    // ReSharper disable once UnusedMember.Global
    ReactiveCommand<TParam, TResult> ReactiveCommandValue { get; }
}