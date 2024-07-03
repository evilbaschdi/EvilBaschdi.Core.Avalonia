using Avalonia.Controls;

namespace EvilBaschdi.Core.Avalonia;

/// <summary>
///     Interface for classes that handle the layout of the current avalonia app.
/// </summary>
public interface IApplicationLayout :
    IRunFor<(bool Center, bool ResizeWithBorder400)>,
    IRunFor<(Window Window, bool Center, bool ResizeWithBorder400)>;