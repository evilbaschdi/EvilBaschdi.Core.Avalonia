using ReactiveUI;
using ReactiveUI.Primitives;

namespace EvilBaschdi.Core.Avalonia.Mvvm.Command;

/// <inheritdoc />
// ReSharper disable once UnusedType.Global
public abstract class ReactiveCommandRxVoidTask : IReactiveCommandRxVoidTask
{
    private readonly Lazy<ReactiveCommand<RxVoid, RxVoid>> _command;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ReactiveCommandRxVoidTask" /> class.
    /// </summary>
    protected ReactiveCommandRxVoidTask()
    {
        _command = new(() => ReactiveCommand.CreateFromTask(RunAsync));
    }

    /// <inheritdoc />
    public ReactiveCommand<RxVoid, RxVoid> Command => _command.Value;

    // ReSharper disable once MemberCanBeProtected.Global
    /// <summary>
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public virtual Task RunAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();
}