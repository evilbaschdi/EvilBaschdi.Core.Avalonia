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
        Load();
        ArchitectureInformation.Text = $"{RuntimeInformation.FrameworkDescription} ({RuntimeInformation.ProcessArchitecture} on {RuntimeInformation.OSArchitecture})".ToLower();
    }

    private void Load()
    {
        var handleOsDependentTitleBar = new HandleOsDependentTitleBar();
        handleOsDependentTitleBar.RunFor(this);

        var applicationLayout = new ApplicationLayout();
        applicationLayout.RunFor((this, true, true));
    }
}