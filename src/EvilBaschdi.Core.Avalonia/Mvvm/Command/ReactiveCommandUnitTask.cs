using System.Reactive;
using ReactiveUI;

namespace EvilBaschdi.Core.Avalonia.Mvvm.Command;

/// <inheritdoc />
// ReSharper disable once UnusedType.Global
public abstract class ReactiveCommandUnitTask : IReactiveCommandUnitTask
{
    /// <inheritdoc />
    public ReactiveCommand<Unit, Unit> Command => ReactiveCommand.CreateFromTask(RunAsync);

    // ReSharper disable once MemberCanBeProtected.Global
    /// <summary>
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public virtual Task RunAsync() => throw new NotImplementedException();
}