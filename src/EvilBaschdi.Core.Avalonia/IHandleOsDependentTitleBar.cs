using Avalonia.Controls;

namespace EvilBaschdi.Core.Avalonia;

/// <inheritdoc />
public interface IHandleOsDependentTitleBar : IRunFor<(Window window, Panel headerPanel, Panel mainPanel)>
{
}