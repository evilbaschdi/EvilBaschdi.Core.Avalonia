using System.Reactive;
using ReactiveUI;

namespace EvilBaschdi.Core.Avalonia.Mvvm.Command;

/// <inheritdoc />
// ReSharper disable once UnusedType.Global
public abstract class ReactiveCommandUnitTask : IReactiveCommandUnitTask
{
    private readonly Lazy<ReactiveCommand<Unit, Unit>> _command;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ReactiveCommandUnitTask" /> class.
    /// </summary>
    protected ReactiveCommandUnitTask()
    {
        _command = new(() => ReactiveCommand.CreateFromTask(RunAsync));
    }

    /// <inheritdoc />
    public ReactiveCommand<Unit, Unit> Command => _command.Value;

    // ReSharper disable once MemberCanBeProtected.Global
    /// <summary>
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public virtual Task RunAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();
}