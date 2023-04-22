using Avalonia.Controls;

namespace EvilBaschdi.Core.Avalonia;

/// <inheritdoc cref="IRunFor{TIn}" />
public interface IHandleOsDependentTitleBar :
    IRun,
    IRunFor<Window>
{
}