using System.Runtime.InteropServices;
using Avalonia.Controls;
using Avalonia.Interactivity;
using FluentAvalonia.UI.Controls;
using MsBox.Avalonia;
using MsBox.Avalonia.Dto;
using MsBox.Avalonia.Enums;

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
    // ReSharper disable once UnusedMember.Local
    private async void ShowMessage(object sender, RoutedEventArgs e)
        // ReSharper restore UnusedParameter.Local
    {
        //var messageBoxStandard = MessageBoxManager.GetMessageBoxStandard(
        //    new MessageBoxStandardParams
        //    {
        //        ButtonDefinitions = ButtonEnum.YesNoCancel,
        //        ContentTitle = "Title with maaaaaaaaaaaaaany signs",
        //        ContentHeader = "Title with maaaaaaaaaaaaaany signs",
        //        ContentMessage = DateTime.Now.ToString("R"),
        //        Icon = MsBox.Avalonia.Enums.Icon.Info,
        //        WindowStartupLocation = WindowStartupLocation.CenterOwner,
        //        CanResize = false,
        //        SizeToContent = SizeToContent.WidthAndHeight,
        //        ShowInCenter = true,
        //        Topmost = false
        //    });
        //var messageBoxResult = await messageBoxStandard.ShowAsPopupAsync(this);
        //MessageBoxResult.Text = messageBoxResult.ToString();

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
        var messageBoxStandard = MessageBoxManager.GetMessageBoxStandard("This a warning message", DateTime.Now.ToString("R"), ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Warning);
        await messageBoxStandard.ShowAsPopupAsync(this);
    }

    // ReSharper disable UnusedParameter.Local
    // ReSharper disable once UnusedMember.Local
    private async void ShowError(object sender, RoutedEventArgs e)
        // ReSharper restore UnusedParameter.Local
    {
        var messageBoxStandard =
            MessageBoxManager.GetMessageBoxStandard("Running out of coffee Exception occurred!", DateTime.Now.ToString("R"), ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Error);
        await messageBoxStandard.ShowAsPopupAsync(this);
    }

    // ReSharper disable UnusedParameter.Local
    // ReSharper disable once UnusedMember.Local
    private async void ShowDialogBox(object sender, RoutedEventArgs e)
        // ReSharper restore UnusedParameter.Local
    {
        var messageBoxStandard = MessageBoxManager.GetMessageBoxStandard(
            new MessageBoxStandardParams
            {
                ButtonDefinitions = ButtonEnum.OkCancel,
                ContentTitle = "Title",
                //ContentHeader = "Title",
                ContentMessage = "Enter the new directory name",
                Icon = MsBox.Avalonia.Enums.Icon.Folder,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                CanResize = false,
                SizeToContent = SizeToContent.WidthAndHeight,
                ShowInCenter = true,
                Topmost = false,
                InputParams = new InputParams
                              {
                                  Multiline = false
                              }
            });

        var inputResult = await messageBoxStandard.ShowAsPopupAsync(this);

        if (inputResult == ButtonResult.Ok && !string.IsNullOrWhiteSpace(messageBoxStandard.InputValue))
        {
            DialogBoxResult.Text = messageBoxStandard.InputValue;
        }
    }
}