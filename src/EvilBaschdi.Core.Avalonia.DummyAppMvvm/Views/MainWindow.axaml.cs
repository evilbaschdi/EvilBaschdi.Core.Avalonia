using Avalonia.Collections;
using Avalonia.Controls;
using EvilBaschdi.Core.Avalonia.DummyAppMvvm.Models;

namespace EvilBaschdi.Core.Avalonia.DummyAppMvvm.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    protected override void OnOpened(EventArgs e)
    {
        base.OnOpened(e);
        IHandleOsDependentTitleBar handleOsDependentTitleBar = new HandleOsDependentTitleBar();
        handleOsDependentTitleBar.RunFor((this, HeaderPanel, MainPanel));

        var thm = ActualThemeVariant;
        IWindowInstance windowInstance = new WindowInstance(this);
        ICalculateImmutableSolidColorBrushColor calculateImmutableSolidColorBrushColor = new CalculateImmutableSolidColorBrushColor(windowInstance);
        ITryEnableMicaEffect tryEnableMicaEffect = new TryEnableMicaEffect(windowInstance, calculateImmutableSolidColorBrushColor);
        IOnRequestedThemeChanged onRequestedThemeChanged = new OnRequestedThemeChanged(tryEnableMicaEffect);
        IApplyFluentAvaloniaUiStyle applyFluentAvaloniaUiStyle = new ApplyFluentAvaloniaUiStyle(windowInstance, onRequestedThemeChanged, tryEnableMicaEffect);

        applyFluentAvaloniaUiStyle.RunFor(thm);

        TargetDataGrid.Items = new DataGridCollectionView(Countries.All)
                               {
                                   GroupDescriptions =
                                   {
                                       new DataGridPathGroupDescription("Region")
                                   }
                               };
    }
}