using System.Runtime.InteropServices;
using Avalonia.Interactivity;
using EvilBaschdi.Core.Avalonia.Behaviors;
using EvilBaschdi.Core.Avalonia.Controls;
using EvilBaschdi.Core.Avalonia.Layout;
using FluentAvalonia.UI.Controls;
using FluentAvalonia.UI.Windowing;

namespace EvilBaschdi.Core.Avalonia.DummyApp;

/// <inheritdoc />
public partial class MainWindow : FAAppWindow
{
    /// <summary>
    ///     Constructor
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
        Load();
        Opened += OnOpened;
        ArchitectureInformation.Text = $"{RuntimeInformation.FrameworkDescription} ({RuntimeInformation.ProcessArchitecture} on {RuntimeInformation.OSArchitecture})".ToLower();
    }

    private void OnOpened(object sender, EventArgs e)
    {
        var windowOpenedBehavior = new WindowOpenedBehavior();
        windowOpenedBehavior.OnWindowOpened(this);
    }

    private void Load()
    {
        TitleBar.ExtendsContentIntoTitleBar = true;

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