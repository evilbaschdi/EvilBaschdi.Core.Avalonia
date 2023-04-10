using Avalonia.Controls;

namespace EvilBaschdi.Core.Avalonia;

/// <inheritdoc cref="IRunFor{TIn}" />
public interface IHandleOsDependentTitleBar : IRunFor<(Window window, Panel headerPanel, Panel mainPanel, ExperimentalAcrylicBorder AcrylicBorder)>
{
}