using System.Runtime.InteropServices;
using Avalonia.Controls;
using Avalonia.Interactivity;
using EvilBaschdi.Core.Avalonia.Controls;
using FluentAvalonia.UI.Controls;

namespace EvilBaschdi.Core.Avalonia.DummyApp;

/// <inheritdoc />
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
    // ReSharper disable once UnusedMember.Local
    private async void ShowMessage(object sender, RoutedEventArgs e)
        // ReSharper restore UnusedParameter.Local
    {
        var contentDialog = new ContentDialog
                            {
                                Title = "Title with maaaaaaaaaaaaaany signs",
                                Content = DateTime.Now.ToString("R"),
                                PrimaryButtonText = "Yes",
                                SecondaryButtonText = "No"
                            };
        var result = await contentDialog.ShowAsync();
        MessageBoxResult.Text = result.ToString();
    }

    // ReSharper disable UnusedParameter.Local
    // ReSharper disable once UnusedMember.Local
    private async void ShowWarning(object sender, RoutedEventArgs e)
        // ReSharper restore UnusedParameter.Local
    {
        var taskDialog = new TaskDialog
                         {
                             Title = "This is a warning message",
                             Content = DateTime.Now.ToString("R"),
                             IconSource = new SymbolIconSource { Symbol = Symbol.AlertFilled },
                             Buttons =
                             {
                                 TaskDialogButton.OKButton,
                             },
                             XamlRoot = this
                         };
        var result = await taskDialog.ShowAsync();
        MessageBoxResult.Text = result.ToString();
    }

    // ReSharper disable UnusedParameter.Local
    // ReSharper disable once UnusedMember.Local
    private async void ShowError(object sender, RoutedEventArgs e)
        // ReSharper restore UnusedParameter.Local
    {
        var taskDialog = new TaskDialog
                         {
                             Title = "Running out of coffee Exception occurred!",
                             Content = DateTime.Now.ToString("R"),
                             IconSource = new SymbolIconSource { Symbol = Symbol.Cancel },
                             Buttons =
                             {
                                 TaskDialogButton.OKButton,
                             },
                             XamlRoot = this
                         };
        var result = await taskDialog.ShowAsync();
        MessageBoxResult.Text = result.ToString();
    }

    // ReSharper disable UnusedParameter.Local
    // ReSharper disable once UnusedMember.Local
    private async void ShowDialogBox(object sender, RoutedEventArgs e)
        // ReSharper restore UnusedParameter.Local
    {
        var dialog = new ContentDialog
                     {
                         Title = "Enter the new directory name",
                         PrimaryButtonText = "Ok",
                         CloseButtonText = "Cancel"
                     };

        var input = new ContentDialogInput
                    {
                        CaptionText = "Enter the new directory name"
                    };
        dialog.Content = input;

        var result = await dialog.ShowAsync();

        if (result == ContentDialogResult.Primary && !string.IsNullOrWhiteSpace(input.ResultText))
        {
            DialogBoxResult.Text = input.ResultText;
        }
    }
}