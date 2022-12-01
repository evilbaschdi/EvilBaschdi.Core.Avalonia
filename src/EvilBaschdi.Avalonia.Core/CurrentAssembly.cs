using System.Reflection;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;

namespace EvilBaschdi.Avalonia.Core;

/// <inheritdoc />
public class CurrentAssembly : ICurrentAssembly
{
    /// <inheritdoc />
    public Assembly Value => ((IClassicDesktopStyleApplicationLifetime)Application.Current?.ApplicationLifetime)?.MainWindow?.GetType().Assembly;
}