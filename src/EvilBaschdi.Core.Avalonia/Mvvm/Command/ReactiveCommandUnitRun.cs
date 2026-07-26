using ReactiveUI;
using ReactiveUI.Primitives;

namespace EvilBaschdi.Core.Avalonia.Mvvm.Command;

/// <inheritdoc />
// ReSharper disable once UnusedType.Global
public abstract class ReactiveCommandRxVoidRun : IReactiveCommandRxVoidRun
{
    private readonly Lazy<ReactiveCommand<RxVoid, RxVoid>> _command;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ReactiveCommandRxVoidRun" /> class.
    /// </summary>
    protected ReactiveCommandRxVoidRun()
    {
        _command = new(() => ReactiveCommand.Create(Run));
    }

    /// <inheritdoc />
    public ReactiveCommand<RxVoid, RxVoid> Command => _command.Value;

    /// <inheritdoc />
    public virtual void Run() => throw new NotImplementedException();
}