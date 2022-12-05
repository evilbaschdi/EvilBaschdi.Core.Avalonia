using Avalonia.Media.Imaging;

namespace EvilBaschdi.Avalonia.Core.Controls.About;

/// <summary>
/// </summary>
public class AboutModel : IAboutModel
{
    /// <summary>
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public string ApplicationTitle { get; set; } = string.Empty;

    /// <summary>
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public string Company { get; set; } = string.Empty;

    /// <summary>
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public string Copyright { get; set; } = string.Empty;

    /// <summary>
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public Bitmap LogoSource { get; set; } = new Bitmap(string.Empty);

    /// <summary>
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public string Runtime { get; set; } = string.Empty;

    /// <summary>
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public string Version { get; set; } = string.Empty;
}