using System;
using Avalonia;
using Avalonia.Controls;
using EvilBaschdi.Avalonia.Core;
using FluentAvalonia.Styling;

namespace EvilBaschdi.Avalonia.DummyApp;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    protected override void OnOpened(EventArgs e)
    {
        base.OnOpened(e);

        var thm = AvaloniaLocator.Current.GetService<FluentAvaloniaTheme>();
        IWindowInstance windowInstance = new WindowInstance(this);
        ITryEnableMicaEffect tryEnableMicaEffect = new TryEnableMicaEffect(windowInstance);
        IOnRequestedThemeChanged onRequestedThemeChanged = new OnRequestedThemeChanged(tryEnableMicaEffect);
        IApplyFluentAvaloniaUiStyle applyFluentAvaloniaUiStyle = new ApplyFluentAvaloniaUiStyle(windowInstance, onRequestedThemeChanged, tryEnableMicaEffect);

        if (thm != null)
        {
            applyFluentAvaloniaUiStyle.RunFor(thm);
        }
    }
}