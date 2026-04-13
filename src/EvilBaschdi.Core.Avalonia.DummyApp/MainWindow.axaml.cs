using System.Runtime.InteropServices;
using Avalonia.Controls;
using Avalonia.Interactivity;
using EvilBaschdi.Core.Avalonia.Controls;
using EvilBaschdi.Core.Avalonia.Layout;
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
        var contentDialog = new FAContentDialog
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
        var taskDialog = new FATaskDialog
                         {
                             Title = "This is a warning message",
                             Content = DateTime.Now.ToString("R"),
                             IconSource = new FASymbolIconSource { Symbol = FASymbol.AlertFilled },
                             Buttons =
                             {
                                 FATaskDialogButton.OKButton,
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
        var taskDialog = new FATaskDialog
                         {
                             Title = "Running out of coffee Exception occurred!",
                             Content = DateTime.Now.ToString("R"),
                             IconSource = new FASymbolIconSource { Symbol = FASymbol.Cancel },
                             Buttons =
                             {
                                 FATaskDialogButton.OKButton,
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
        var dialog = new FAContentDialog
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

        if (result == FAContentDialogResult.Primary && !string.IsNullOrWhiteSpace(input.ResultText))
        {
            DialogBoxResult.Text = input.ResultText;
        }
    }
}