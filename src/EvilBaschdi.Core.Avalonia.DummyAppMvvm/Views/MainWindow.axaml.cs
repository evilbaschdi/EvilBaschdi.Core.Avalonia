using Avalonia.Collections;
using Avalonia.Controls;
using EvilBaschdi.Core.Avalonia.DummyAppMvvm.Models;
using Microsoft.Extensions.DependencyInjection;

#pragma warning disable IDE0079
#pragma warning disable CA1859
#pragma warning restore IDE0079

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
        Load();
    }

    protected override void OnOpened(EventArgs e)
    {
        base.OnOpened(e);

        TargetDataGrid.ItemsSource = new DataGridCollectionView(Countries.Value)
                                     {
                                         GroupDescriptions =
                                         {
                                             new DataGridPathGroupDescription("Region")
                                         }
                                     };
    }

    private void Load()
    {
        var handleOsDependentTitleBar = App.ServiceProvider?.GetRequiredService<IHandleOsDependentTitleBar>();
        handleOsDependentTitleBar?.RunFor(this);

        var applicationLayout = App.ServiceProvider?.GetRequiredService<IApplicationLayout>();
        applicationLayout?.RunFor((this, true, true));
    }
}