using System.Reactive;
using ReactiveUI;

namespace EvilBaschdi.Core.Avalonia.Mvvm.Command;

/// <inheritdoc />
public abstract class ReactiveCommandUnitRun : IReactiveCommandUnitRun
{
    /// <inheritdoc />
    public ReactiveCommand<Unit, Unit> ReactiveCommandValue => ReactiveCommand.Create(Run);

    /// <inheritdoc />
    public virtual void Run()
    {
        throw new NotImplementedException();
    }
}