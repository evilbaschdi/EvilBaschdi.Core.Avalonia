using Avalonia.Controls;
using Avalonia.Media;
using EvilBaschdi.Core.Avalonia.Internal;

namespace EvilBaschdi.Core.Avalonia;

/// <inheritdoc />
public partial class MessageBox : Window
{
    /// <summary>
    ///     Constructor
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public MessageBox()
    {
        InitializeComponent();
        Load();
    }

    private void Load()
    {
        var handleOsDependentTitleBar = new HandleOsDependentTitleBar();
        handleOsDependentTitleBar.RunFor(this);

        var applicationLayout = new ApplicationLayout();
        applicationLayout.RunFor((this, true, true));
    }

    /// <summary>
    ///     Show MessageBox
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="text"></param>
    /// <param name="title"></param>
    /// <param name="buttons"></param>
    /// <param name="boxType"></param>
    /// <returns></returns>
    public static Task<MessageBoxResult> Show(Window parent, string text, string title, MessageBoxButtons buttons, MessageBoxType boxType = MessageBoxType.Default)
    {
        var msgbox = new MessageBox
                     {
                         Title = title
                     };

        var textControl = msgbox.FindControl<TextBlock>("Text");
        var messageBoxTitleControl = msgbox.FindControl<TextBlock>("MessageBoxTitle");
        if (textControl != null)
        {
            textControl.Text = text;

            if (messageBoxTitleControl != null)
            {
                messageBoxTitleControl.Text = title;

                switch (boxType)
                {
                    case MessageBoxType.Default:
                        break;
                    case MessageBoxType.Warning:
                        messageBoxTitleControl.Foreground = Brushes.DarkOrange;
                        textControl.Foreground = Brushes.DarkOrange;
                        break;
                    case MessageBoxType.Error:
                        messageBoxTitleControl.Foreground = Brushes.Red;
                        textControl.Foreground = Brushes.Red;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(boxType), boxType, null);
                }
            }
        }

        var buttonPanel = msgbox.FindControl<StackPanel>("Buttons");

        switch (buttons)
        {
            case MessageBoxButtons.Ok or MessageBoxButtons.OkCancel:
                AddButton("Ok", MessageBoxResult.Ok);
                break;
            case MessageBoxButtons.YesNo or MessageBoxButtons.YesNoCancel:
                AddButton("Yes", MessageBoxResult.Yes);
                AddButton("No", MessageBoxResult.No);
                break;
        }

        if (buttons is MessageBoxButtons.OkCancel or MessageBoxButtons.YesNoCancel)
        {
            AddButton("Cancel", MessageBoxResult.Cancel);
        }

        var taskCompletionSource = new TaskCompletionSource<MessageBoxResult>();
        var result = MessageBoxResult.Ok;
        msgbox.Closed += delegate { taskCompletionSource.TrySetResult(result); };
        if (parent != null)
        {
            msgbox.ShowDialog(parent);
        }
        else
        {
            msgbox.Show();
        }

        return taskCompletionSource.Task;

        void AddButton(string caption, MessageBoxResult messageBoxResult)
        {
            var btn = new Button { Content = caption };
            btn.Click += (_, _) =>
                         {
                             result = messageBoxResult;
                             msgbox.Close();
                         };
            buttonPanel?.Children.Add(btn);
        }
    }
}