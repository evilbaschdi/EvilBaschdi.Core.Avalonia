using ReactiveUI;

namespace EvilBaschdi.Core.Avalonia.Mvvm.Command;

/// <summary>IInitReactiveCommand</summary>
public interface IInitReactiveCommand<TParam, TResult>
{
    /// <inheritdoc cref="ReactiveCommand" />
    // ReSharper disable once UnusedMember.Global
    ReactiveCommand<TParam, TResult> Command { get; }
}