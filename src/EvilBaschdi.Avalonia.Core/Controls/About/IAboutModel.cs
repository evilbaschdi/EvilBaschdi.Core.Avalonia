using Avalonia.Media.Imaging;

namespace EvilBaschdi.Avalonia.Core.Controls.About;

/// <summary>
/// </summary>
public interface IAboutModel
{
    /// <summary>
    /// </summary>
    // ReSharper disable once UnusedType.Global
    // ReSharper disable once UnusedMemberInSuper.Global
    public string ApplicationTitle { get; }

    /// <summary>
    /// </summary>
    // ReSharper disable once UnusedType.Global
    // ReSharper disable once UnusedMemberInSuper.Global
    public string Company { get; }

    /// <summary>
    /// </summary>
    // ReSharper disable once UnusedType.Global
    // ReSharper disable once UnusedMemberInSuper.Global
    public string Copyright { get; }

    /// <summary>
    /// </summary>
    // ReSharper disable once UnusedType.Global
    // ReSharper disable once UnusedMemberInSuper.Global
    public string Description { get; }

    /// <summary>
    /// </summary>
    // ReSharper disable once UnusedType.Global
    // ReSharper disable once UnusedMemberInSuper.Global
    public Bitmap LogoSource { get; }

    /// <summary>
    /// </summary>
    // ReSharper disable once UnusedType.Global
    // ReSharper disable once UnusedMemberInSuper.Global
    public string Runtime { get; }

    /// <summary>
    /// </summary>
    // ReSharper disable once UnusedType.Global
    // ReSharper disable once UnusedMemberInSuper.Global
    public string Version { get; }
}