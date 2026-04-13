using Avalonia.Media;

namespace EvilBaschdi.Core.Avalonia.Themes;

/// <inheritdoc />
public class LinuxThemeColorProvider : IThemeColorProvider
{
    /// <inheritdoc />
    public (Color Accent, Color Background) GetSystemColors()
    {
        var de = DetectDesktopEnvironment();

        var colors = de switch
        {
            "gnome" => GetGnomeColors(),
            "kde" => GetKdeColors(),
            "cinnamon" => GetCinnamonColors(),
            _ => (null, null)
        };

        return (colors.Accent ?? Color.Parse("#4488FF"), colors.Background ?? Color.Parse("#202020"));
    }

    // ------------------------------------------------------------
    // Desktop Environment Detection
    // ------------------------------------------------------------
    private string DetectDesktopEnvironment()
    {
        var de = Environment.GetEnvironmentVariable("XDG_CURRENT_DESKTOP")?.ToLower() ?? "";

        if (de.Contains("gnome"))
        {
            return "gnome";
        }

        if (de.Contains("kde"))
        {
            return "kde";
        }

        if (de.Contains("cinnamon"))
        {
            return "cinnamon";
        }

        return "unknown";
    }

    // ------------------------------------------------------------
    // GNOME (GTK4 / Libadwaita)
    // ------------------------------------------------------------
    private (Color? Accent, Color? Background) GetGnomeColors()
    {
        var version = GetGnomeMajorVersion();

        if (version >= 45)
        {
            return GetGnomeLibadwaitaColors(); // moderner Weg
        }

        return GetGnomeGtkCssColors(); // alter Weg
    }

    private int GetGnomeMajorVersion()
    {
        try
        {
            using var p = new System.Diagnostics.Process();
            p.StartInfo = new()
                          {
                              FileName = "gnome-shell",
                              Arguments = "--version",
                              RedirectStandardOutput = true,
                              UseShellExecute = false
                          };
            p.Start();
            var output = p.StandardOutput.ReadToEnd();
            var parts = output.Split(' ');
            if (parts.Length >= 3 && int.TryParse(parts[2].Split('.')[0], out var version))
            {
                return version;
            }
        }
        catch
        {
            // ignored
        }

        return -1;
    }

    private (Color? Accent, Color? Background) GetGnomeLibadwaitaColors()
    {
        var accentIndexStr = RunGSettings("org.gnome.desktop.interface", "accent-color");
        var scheme = RunGSettings("org.gnome.desktop.interface", "color-scheme");

        var accentIndex = int.TryParse(accentIndexStr, out var idx) ? idx : -1;

        string[] palette =
        {
            "#3584e4", "#9141ac", "#e01b24", "#ff7800", "#f6d32d",
            "#33d17a", "#1c71d8", "#613583", "#c01c28", "#e66100"
        };

        var accent = accentIndex >= 0 && accentIndex < palette.Length
            ? Color.Parse(palette[accentIndex])
            : Color.Parse("#3584e4");

        var dark = scheme.Contains("dark");
        var background = dark
            ? Color.Parse("#1e1e1e")
            : Color.Parse("#ffffff");

        return (accent, background);
    }

    private (Color? Accent, Color? Background) GetGnomeGtkCssColors()
    {
        var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        var gtkCss = Path.Combine(home, ".config/gtk-4.0/gtk.css");

        var accent = ParseGtkCssColor(gtkCss, "accent_color");
        var bg = ParseGtkCssColor(gtkCss, "window_bg_color");

        return (accent, bg);
    }

    private string RunGSettings(string schema, string key)
    {
        try
        {
            using var p = new System.Diagnostics.Process();
            p.StartInfo = new()
                          {
                              FileName = "gsettings",
                              Arguments = $"get {schema} {key}",
                              RedirectStandardOutput = true,
                              RedirectStandardError = true,
                              UseShellExecute = false,
                              CreateNoWindow = true
                          };

            p.Start();
            var output = p.StandardOutput.ReadToEnd().Trim();
            p.WaitForExit();

            // gsettings gibt Strings in Quotes zurück → entfernen
            return output.Trim('\'', '"');
        }
        catch
        {
            return "";
        }
    }

    // ------------------------------------------------------------
    // KDE Plasma
    // ------------------------------------------------------------
    private (Color? Accent, Color? Background) GetKdeColors()
    {
        var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        var kdeglobals = Path.Combine(home, ".config/kdeglobals");

        var accent = ParseKdeColor(kdeglobals, "Colors:Selection", "BackgroundNormal");
        var bg = ParseKdeColor(kdeglobals, "Colors:Window", "BackgroundNormal");

        return (accent, bg);
    }

    // ------------------------------------------------------------
    // Cinnamon (GTK3 Themes)
    // ------------------------------------------------------------
    private (Color? Accent, Color? Background) GetCinnamonColors()
    {
        var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        var settingsIni = Path.Combine(home, ".config/gtk-3.0/settings.ini");

        var themeName = ParseGtkThemeName(settingsIni);
        if (themeName == null)
        {
            return (null, null);
        }

        var themeCss = $"/usr/share/themes/{themeName}/gtk-3.0/gtk.css";

        var accent = ParseGtkCssColor(themeCss, "accent_color");
        var bg = ParseGtkCssColor(themeCss, "window_bg_color");

        return (accent, bg);
    }

    // ------------------------------------------------------------
    // Helpers
    // ------------------------------------------------------------
    private Color? ParseGtkCssColor(string cssPath, string variable)
    {
        if (!File.Exists(cssPath))
        {
            return null;
        }

        foreach (var line in File.ReadLines(cssPath))
        {
            if (line.Contains(variable))
            {
                var hex = line.Split('#').Last().Trim().TrimEnd(';');
                return Color.Parse("#" + hex);
            }
        }

        return null;
    }

    private Color? ParseKdeColor(string file, string section, string key)
    {
        if (!File.Exists(file))
        {
            return null;
        }

        var lines = File.ReadAllLines(file);
        var inSection = false;

        foreach (var line in lines)
        {
            if (line.Trim() == $"[{section}]")
            {
                inSection = true;
                continue;
            }

            if (line.StartsWith("["))
            {
                inSection = false;
            }

            if (inSection && line.StartsWith(key))
            {
                var rgb = line.Split('=').Last().Split(',');
                return Color.FromRgb(
                    byte.Parse(rgb[0]),
                    byte.Parse(rgb[1]),
                    byte.Parse(rgb[2])
                );
            }
        }

        return null;
    }

    private string ParseGtkThemeName(string settingsIni)
    {
        if (!File.Exists(settingsIni))
        {
            return null;
        }

        foreach (var line in File.ReadLines(settingsIni))
        {
            if (line.StartsWith("gtk-theme-name"))
            {
                return line.Split('=').Last().Trim();
            }
        }

        return null;
    }
}