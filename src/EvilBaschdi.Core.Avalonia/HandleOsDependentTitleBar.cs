using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Platform;
using Avalonia.Styling;
using EvilBaschdi.Core.Extensions;

namespace EvilBaschdi.Core.Avalonia;

/// <inheritdoc />
public class HandleOsDependentTitleBar : IHandleOsDependentTitleBar
{
    /// <inheritdoc />
    public void RunFor((Window window, Panel headerPanel, Panel mainPanel, ExperimentalAcrylicBorder AcrylicBorder) value)
    {
        var (window, headerPanel, mainPanel, acrylicBorder) = value;

        if (acrylicBorder != null)
        {
            if (window.ActualThemeVariant == ThemeVariant.Dark)
            {
                acrylicBorder.Material.TintColor = Colors.Black;
            }
            else if (window.ActualThemeVariant == ThemeVariant.Light)
            {
                acrylicBorder.Material.TintColor = Colors.White;
            }
        }

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