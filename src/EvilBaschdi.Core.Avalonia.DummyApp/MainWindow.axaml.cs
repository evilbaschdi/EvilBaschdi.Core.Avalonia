using System.ComponentModel;
using System.Runtime.InteropServices;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MsBox.Avalonia;
using MsBox.Avalonia.Dto;
using MsBox.Avalonia.Enums;
using MsBox.Avalonia.Models;

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
        var messageBoxStandard = MessageBoxManager.GetMessageBoxStandard(
            new MessageBoxStandardParams
            {
                ButtonDefinitions = ButtonEnum.YesNoCancel,
                ContentTitle = "Title with maaaaaaaaaaaaaany signs",
                ContentHeader = "Title with maaaaaaaaaaaaaany signs",
                ContentMessage = DateTime.Now.ToString("R"),
                Icon = MsBox.Avalonia.Enums.Icon.Info,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                CanResize = false,
                SizeToContent = SizeToContent.WidthAndHeight,
                ShowInCenter = true,
                Topmost = false
            });
        var messageBoxResult = await messageBoxStandard.ShowAsPopupAsync(this);
        MessageBoxResult.Text = messageBoxResult.ToString();
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
            MessageBoxManager.GetMessageBoxStandard("Running out of coffee Exception occured!", DateTime.Now.ToString("R"), ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Error);
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

    // ReSharper disable UnusedParameter.Local
    // ReSharper disable once UnusedMember.Local
    private async void ShowProgressBox(object sender, RoutedEventArgs e)
        // ReSharper restore UnusedParameter.Local
    {
        //var result = await ProgressBox.Show(this, "wait until finished", "Progress");
        var messageBoxCustomParams = new MessageBoxCustomParams
                                     {
                                         ButtonDefinitions = new List<ButtonDefinition>
                                                             {
                                                                 new ButtonDefinition { Name = "Cancel", }
                                                             },
                                         ContentMessage = "wait until finished",
                                         ContentTitle = "Progress",
                                         ContentHeader = "Progress",
                                         InputParams = new InputParams
                                                       {
                                                           Label = "%",
                                                           DefaultValue = "0"
                                                       }
                                     };
        var messageBoxCustom = MessageBoxManager.GetMessageBoxCustom(messageBoxCustomParams);

        await messageBoxCustom.ShowAsPopupAsync(this);

        BackgroundWorker worker = new BackgroundWorker();
        worker.WorkerReportsProgress = true;
        worker.DoWork += WorkerDoWork;
        worker.ProgressChanged += WorkerProgressChanged;

        worker.RunWorkerAsync();
    }

    void WorkerDoWork(object sender, DoWorkEventArgs e)
    {
        for (int i = 0; i < 100; i++)
        {
            (sender as BackgroundWorker)?.ReportProgress(i);
            Thread.Sleep(100);
        }
    }

    void WorkerProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        ProgressBoxResult.Value = e.ProgressPercentage;
    }
}