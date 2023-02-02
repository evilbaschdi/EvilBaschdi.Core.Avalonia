using System.Reflection;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;

namespace EvilBaschdi.Core.Avalonia;

/// <inheritdoc />
public class CurrentAssembly : ICurrentAssembly
{
    /// <inheritdoc />
    public Assembly Value => ((IClassicDesktopStyleApplicationLifetime)Application.Current?.ApplicationLifetime)?.MainWindow?.GetType().Assembly;
}