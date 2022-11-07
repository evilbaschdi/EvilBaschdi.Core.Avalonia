using Avalonia.Controls;

namespace EvilBaschdi.Avalonia.Core;

/// <inheritdoc />
public interface IHandleOsDependentTitleBar : IRunFor<(Window window, Panel headerPanel, Panel mainPanel)>
{
}