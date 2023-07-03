using System.Runtime.InteropServices;
using Avalonia.Controls;
using Avalonia.Interactivity;
using EvilBaschdi.Core.Avalonia.Internal;

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
    private async void ShowMessage(object? sender, RoutedEventArgs e)
        // ReSharper restore UnusedParameter.Local
    {
        var messageBoxResult = await MessageBox.Show(this, DateTime.Now.ToString("R"), "Title with maaaaaaaaaaaaaany signs", MessageBoxButtons.YesNoCancel);

        MessageBoxResult.Text = messageBoxResult.ToString();
    }

    // ReSharper disable UnusedParameter.Local
    private async void ShowWarning(object? sender, RoutedEventArgs e)
        // ReSharper restore UnusedParameter.Local
    {
        await MessageBox.Show(this,
            DateTime.Now.ToString("R"), "This a warning message",
            MessageBoxButtons.Ok,
            MessageBoxType.Warning);
    }

    // ReSharper disable UnusedParameter.Local
    private async void ShowError(object? sender, RoutedEventArgs e)
        // ReSharper restore UnusedParameter.Local
    {
        await MessageBox.Show(this, "Running out of coffee Exception occured!", "Developer out of order", MessageBoxButtons.Ok,
            MessageBoxType.Error);
    }

    // ReSharper disable UnusedParameter.Local
    private async void ShowDialogBox(object? sender, RoutedEventArgs e)
        // ReSharper restore UnusedParameter.Local
    {
        {
            var result = await DialogBox.Show(this, "Please enter some text:", "Title");

            DialogBoxResult.Text = result;
        }
    }
}