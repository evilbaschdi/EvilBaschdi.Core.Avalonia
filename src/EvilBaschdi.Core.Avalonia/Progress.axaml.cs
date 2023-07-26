using Avalonia.Controls;
using EvilBaschdi.Core.Avalonia.Internal;

namespace EvilBaschdi.Core.Avalonia;

/// <inheritdoc />
public partial class ProgressBox : Window
{
    /// <summary>
    ///     Constructor
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public ProgressBox()
    {
        InitializeComponent();
        Load();
    }

    private void Load()
    {
        var handleOsDependentTitleBar = new HandleOsDependentTitleBar();
        handleOsDependentTitleBar.RunFor(this);

        var applicationLayout = new ApplicationLayout();
        applicationLayout.RunFor((this, true, false));
    }

    /// <summary>
    ///     Show MessageBox
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="text"></param>
    /// <param name="title"></param>
    /// <returns></returns>
    public static Task<MessageBoxResult> Show(Window parent, string text, string title)
    {
        var progressBox = new ProgressBox
                          {
                              Title = title
                          };

        var textControl = progressBox.FindControl<TextBlock>("Text");
        var messageBoxTitleControl = progressBox.FindControl<TextBlock>("MessageBoxTitle");
        if (textControl != null)
        {
            textControl.Text = text;

            if (messageBoxTitleControl != null)
            {
                messageBoxTitleControl.Text = title;
            }
        }

        var buttonPanel = progressBox.FindControl<StackPanel>("Buttons");
        //var inputControl = progressBox.FindControl<ProgressBar>("Input");

        //AddButton("Ok");
        AddButton("Cancel", MessageBoxResult.Cancel);

        var taskCompletionSource = new TaskCompletionSource<MessageBoxResult>();
        var result = MessageBoxResult.Ok;
        progressBox.Closed += delegate { taskCompletionSource.TrySetResult(result); };
        if (parent != null)
        {
            progressBox.ShowDialog(parent);
        }
        else
        {
            progressBox.Show();
        }

        return taskCompletionSource.Task;

        void AddButton(string caption, MessageBoxResult messageBoxResult)
        {
            var btn = new Button { Content = caption };
            btn.Click += (_, _) =>
                         {
                             result = messageBoxResult;
                             progressBox.Close();
                         };
            buttonPanel?.Children.Add(btn);
        }
    }

    /// <summary>
    /// </summary>
    public double Value
    {
        get => Input.Value;
        set => Input.Value = value;
    }
}