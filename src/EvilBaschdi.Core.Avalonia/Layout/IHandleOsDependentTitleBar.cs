using Avalonia.Controls;

namespace EvilBaschdi.Core.Avalonia.Layout;

/// <inheritdoc cref="IRunFor{TIn}" />
public interface IHandleOsDependentTitleBar :
    IRun,
    IRunFor<Window>;