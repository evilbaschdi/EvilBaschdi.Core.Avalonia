using Avalonia.Controls;

namespace EvilBaschdi.Core.Avalonia;

/// <inheritdoc />
public partial class MessageBox : Window
{
    /// <summary>
    /// </summary>
    public enum MessageBoxButtons
    {
        /// <summary>
        /// </summary>
        Ok,

        /// <summary>
        /// </summary>
        OkCancel,

        /// <summary>
        /// </summary>
        YesNo,

        /// <summary>
        /// </summary>
        YesNoCancel
    }

    /// <summary>
    /// </summary>
    public enum MessageBoxResult
    {
        /// <summary>
        /// </summary>
        Ok,

        /// <summary>
        /// </summary>
        Cancel,

        /// <summary>
        /// </summary>
        Yes,

        /// <summary>
        /// </summary>
        No
    }

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
    /// <returns></returns>
    public static Task<MessageBoxResult> Show(Window parent, string text, string title, MessageBoxButtons buttons)
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
        }

        if (messageBoxTitleControl != null)
        {
            messageBoxTitleControl.Text = title;
        }

        var buttonPanel = msgbox.FindControl<StackPanel>("Buttons");

        switch (buttons)
        {
            case MessageBoxButtons.Ok or MessageBoxButtons.OkCancel:
                AddButton("Ok", MessageBoxResult.Ok, true);
                break;
            case MessageBoxButtons.YesNo or MessageBoxButtons.YesNoCancel:
                AddButton("Yes", MessageBoxResult.Yes);
                AddButton("No", MessageBoxResult.No, true);
                break;
        }

        if (buttons is MessageBoxButtons.OkCancel or MessageBoxButtons.YesNoCancel)
        {
            AddButton("Cancel", MessageBoxResult.Cancel, true);
        }

        var tcs = new TaskCompletionSource<MessageBoxResult>();
        var res = MessageBoxResult.Ok;
        msgbox.Closed += delegate { tcs.TrySetResult(res); };
        if (parent != null)
        {
            msgbox.ShowDialog(parent);
        }
        else
        {
            msgbox.Show();
        }

        return tcs.Task;

        void AddButton(string caption, MessageBoxResult r, bool def = false)
        {
            var btn = new Button { Content = caption };
            btn.Click += (_, _) =>
                         {
                             res = r;
                             msgbox.Close();
                         };
            buttonPanel?.Children.Add(btn);

            if (def)
            {
                res = r;
            }
        }
    }
}