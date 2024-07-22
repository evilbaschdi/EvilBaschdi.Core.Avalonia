using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Threading;

namespace EvilBaschdi.Core.Avalonia.Controls;

/// <inheritdoc />
public partial class ContentDialogInput : UserControl
{
    /// <summary>
    ///     Text to display as caption inside the dialog
    /// </summary>
    public string CaptionText { get; init; }

    /// <summary>
    ///     Text to transport the result text
    /// </summary>
    public string ResultText { get; private set; }

    /// <summary>
    ///     Constructor
    /// </summary>
    public ContentDialogInput()
    {
        InitializeComponent();
        Caption.Text = CaptionText;
    }

    // ReSharper disable once UnusedParameter.Local
    // ReSharper disable once UnusedMember.Local
    private void InputFieldOnAttachedToVisualTree(object sender, VisualTreeAttachmentEventArgs e)
    {
        // We will set the focus into our input field just after it got attached to the visual tree.
        if (sender is InputElement inputElement)
        {
            Dispatcher.UIThread.InvokeAsync(() => { inputElement.Focus(); });
        }
    }

    // ReSharper disable once UnusedMember.Local
    // ReSharper disable UnusedParameter.Local
    private void ResultOnTextChanged(object sender, TextChangedEventArgs e)
        // ReSharper restore UnusedParameter.Local
    {
        ResultText = Result.Text;
    }
}