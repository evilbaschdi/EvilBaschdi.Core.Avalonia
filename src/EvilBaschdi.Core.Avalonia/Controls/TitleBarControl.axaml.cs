using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace EvilBaschdi.Core.Avalonia.Controls;

/// <inheritdoc />
public partial class TitleBarControl : UserControl
{
    /// <summary>
    ///     Constructor
    /// </summary>
    public TitleBarControl()
    {
        InitializeComponent();
    }

    /// <summary>
    ///     The icon displayed in the title bar.
    /// </summary>
    public static readonly StyledProperty<IImage> IconProperty = AvaloniaProperty.Register<TitleBarControl, IImage>(nameof(Icon));

    /// <summary>
    ///     Gets or sets the icon displayed in the title bar.
    /// </summary>
    public IImage Icon
    {
        get => GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }
}