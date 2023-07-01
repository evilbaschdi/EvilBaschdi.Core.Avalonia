using System.Runtime.InteropServices;
using Avalonia.Controls;
using Avalonia.Interactivity;

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

    // ReSharper disable UnusedParameter.Local
    private async void ShowMessageBox(object? sender, RoutedEventArgs e)
        // ReSharper restore UnusedParameter.Local
    {
        var messageBoxResult = await MessageBox.Show(this, DateTime.Now.ToString("R"), "Title with maaaaaaaaaaaaaany signs", MessageBox.MessageBoxButtons.YesNoCancel);

        MessageBoxResult.Text = messageBoxResult.ToString();
    }
}