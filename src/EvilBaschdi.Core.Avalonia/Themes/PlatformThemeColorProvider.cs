using Avalonia.Media;
using EvilBaschdi.Core.Enums;
using EvilBaschdi.Core.Extensions;

namespace EvilBaschdi.Core.Avalonia.Themes;

/// <inheritdoc />
public class PlatformThemeColorProvider : IThemeColorProvider
{
    /// <inheritdoc />
    public (Color Accent, Color Background) GetSystemColors()
    {
        IThemeColorProvider provider = VersionHelper.CurrentPlatform switch
        {
            PlatformKind.Windows => new WindowsThemeColorProvider(),
            PlatformKind.OSX => new MacThemeColorProvider(),
            PlatformKind.Linux => new LinuxThemeColorProvider(),
            _ => throw new ArgumentOutOfRangeException()
        };

        return provider.GetSystemColors();
    }
}