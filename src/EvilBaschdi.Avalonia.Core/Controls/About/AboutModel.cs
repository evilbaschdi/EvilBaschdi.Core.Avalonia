using Avalonia.Media.Imaging;

namespace EvilBaschdi.Avalonia.Core.Controls.About;

/// <summary>
/// </summary>
public class AboutModel : IAboutModel
{
    /// <summary>
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public string ApplicationTitle { get; set; }

    /// <summary>
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public string Company { get; set; }

    /// <summary>
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public string Copyright { get; set; }

    /// <summary>
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public string Description { get; set; }

    /// <summary>
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public Bitmap LogoSource { get; set; }

    /// <summary>
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public string Runtime { get; set; }

    /// <summary>
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public string Version { get; set; }
}