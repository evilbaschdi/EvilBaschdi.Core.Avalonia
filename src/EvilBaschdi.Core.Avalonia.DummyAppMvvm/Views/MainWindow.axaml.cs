using Avalonia.Controls;
using EvilBaschdi.Core.Avalonia.Behaviors;
using EvilBaschdi.Core.Avalonia.DependencyInjection;
using EvilBaschdi.Core.Avalonia.Layout;
using Microsoft.Extensions.DependencyInjection;

namespace EvilBaschdi.Core.Avalonia.DummyAppMvvm.Views;

/// <summary>
///     The main window.
/// </summary>
public partial class MainWindow : Window
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MainWindow" /> class.
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
        ApplyLayout();
        Opened += OnOpened;
    }

    private void OnOpened(object sender, EventArgs e)
    {
        var windowOpenedBehavior = ApplicationServices.ServiceProvider?.GetRequiredService<IWindowOpenedBehavior>();
        windowOpenedBehavior?.OnWindowOpened(this);
    }

    private void ApplyLayout()
    {
        //var handleOsDependentTitleBar = ApplicationServices.ServiceProvider?.GetRequiredService<IHandleOsDependentTitleBar>();
        //handleOsDependentTitleBar?.RunFor(this);

        var applicationLayout = ApplicationServices.ServiceProvider?.GetRequiredService<IApplicationLayout>();
        applicationLayout?.RunFor((this, true, true));
    }
}