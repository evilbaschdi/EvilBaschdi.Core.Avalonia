using System.Runtime.InteropServices;
using Avalonia.Controls;

namespace EvilBaschdi.Core.Avalonia.DummyApp;

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
        var handleOsDependentTitleBar = new HandleOsDependentTitleBar();
        handleOsDependentTitleBar.RunFor((this, HeaderPanel, MainPanel, AcrylicBorder));

        var applicationLayout = new ApplicationLayout(true, true);
        applicationLayout.Run();

        ArchitectureInformation.Text = $"{RuntimeInformation.FrameworkDescription} ({RuntimeInformation.ProcessArchitecture} on {RuntimeInformation.OSArchitecture})".ToLower();
    }
}