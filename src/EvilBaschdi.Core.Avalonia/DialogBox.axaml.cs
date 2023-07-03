using Avalonia.Controls;

namespace EvilBaschdi.Core.Avalonia;

/// <inheritdoc />
public partial class DialogBox : Window
{
    /// <summary>
    ///     Constructor
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public DialogBox()
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
    public static Task<string> Show(Window parent, string text, string title)
    {
        var dialogBox = new DialogBox
                        {
                            Title = title
                        };

        var textControl = dialogBox.FindControl<TextBlock>("Text");
        var messageBoxTitleControl = dialogBox.FindControl<TextBlock>("MessageBoxTitle");
        if (textControl != null)
        {
            textControl.Text = text;

            if (messageBoxTitleControl != null)
            {
                messageBoxTitleControl.Text = title;
            }
        }

        var buttonPanel = dialogBox.FindControl<StackPanel>("Buttons");
        var inputControl = dialogBox.FindControl<TextBox>("Input");

        AddButton("Ok");
        AddButton("Cancel");

        var tcs = new TaskCompletionSource<string>();
        var res = inputControl?.Text;
        dialogBox.Closed += delegate { tcs.TrySetResult(res); };
        if (parent != null)
        {
            dialogBox.ShowDialog(parent);
        }
        else
        {
            dialogBox.Show();
        }

        return tcs.Task;

        void AddButton(string caption)
        {
            var btn = new Button { Content = caption };
            btn.Click += (_, _) =>
                         {
                             res = inputControl?.Text;
                             dialogBox.Close();
                         };
            buttonPanel?.Children.Add(btn);
        }
    }
}