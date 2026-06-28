using System.Reactive;
using ReactiveUI;

namespace EvilBaschdi.Core.Avalonia.Mvvm.Command;

/// <inheritdoc />
// ReSharper disable once UnusedType.Global
public abstract class ReactiveCommandUnitRun : IReactiveCommandUnitRun
{
    private readonly Lazy<ReactiveCommand<Unit, Unit>> _command;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ReactiveCommandUnitRun" /> class.
    /// </summary>
    protected ReactiveCommandUnitRun()
    {
        _command = new(() => ReactiveCommand.Create(Run));
    }

    /// <inheritdoc />
    public ReactiveCommand<Unit, Unit> Command => _command.Value;

    /// <inheritdoc />
    public virtual void Run() => throw new NotImplementedException();
}