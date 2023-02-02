using Avalonia.Controls;
using Avalonia.Platform;
using EvilBaschdi.Core.Extensions;

namespace EvilBaschdi.Core.Avalonia;

/// <inheritdoc />
public class HandleOsDependentTitleBar : IHandleOsDependentTitleBar
{
    /// <inheritdoc />
    public void RunFor((Window window, Panel headerPanel, Panel mainPanel) value)
    {
        var (window, headerPanel, mainPanel) = value;

        if (!VersionHelper.IsWindows)
        {
            return;
        }

        window.ExtendClientAreaToDecorationsHint = true;
        window.ExtendClientAreaChromeHints = ExtendClientAreaChromeHints.Default;
        headerPanel.IsVisible = true;
        mainPanel.Margin = new(0, 30, 0, 0);
    }
}