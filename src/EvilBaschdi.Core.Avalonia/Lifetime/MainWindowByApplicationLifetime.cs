using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;

namespace EvilBaschdi.Core.Avalonia.Lifetime;

/// <inheritdoc />
public class MainWindowByApplicationLifetime : IMainWindowByApplicationLifetime
{
    /// <inheritdoc />
    public Window Value => Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop ? desktop.MainWindow : null;
}