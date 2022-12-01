using Avalonia.Controls;
using Avalonia.Interactivity;
using EvilBaschdi.Avalonia.Core;
using EvilBaschdi.Avalonia.Core.Controls.About;
using EvilBaschdi.Core;

namespace EvilBaschdi.Avalonia.DummyApp;

public partial class MainWindow : Window
{
    /// <summary>
    ///     Constructor
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
    }

    protected override void OnOpened(EventArgs e)
    {
        base.OnOpened(e);
        IHandleOsDependentTitleBar handleOsDependentTitleBar = new HandleOsDependentTitleBar();
        handleOsDependentTitleBar.RunFor((this, HeaderPanel, MainPanel));
    }

    // ReSharper disable UnusedParameter.Local
    private void AboutClick(object? sender, RoutedEventArgs e)
        // ReSharper restore UnusedParameter.Local
    {
        ICurrentAssembly currentAssembly = new CurrentAssembly();
        IAboutContent aboutContent = new AboutContent(currentAssembly);
        IAboutModel aboutModel = new AboutViewModel(aboutContent);
        var aboutWindow = new AboutWindow
                          {
                              DataContext = aboutModel
                          };
        aboutWindow.ShowDialog(this);
    }
}