using AvaloniaEdit.TextMate;
using EvilBaschdi.Core.Avalonia.DependencyInjection;
using EvilBaschdi.Core.Avalonia.DummyAppMvvm.ViewModels;
using EvilBaschdi.Core.Avalonia.Themes;
using FluentAvalonia.UI.Windowing;
using Microsoft.Extensions.DependencyInjection;
using TextMateSharp.Grammars;

namespace EvilBaschdi.Core.Avalonia.DummyAppMvvm.Views;

/// <inheritdoc />
public partial class ExtendedInformation : FAAppWindow
{
    /// <summary>
    ///     Constructor
    /// </summary>
    public ExtendedInformation()
    {
        InitializeComponent();

        var registryOptions = new RegistryOptions(ThemeName.DarkPlus);

        var textMateInstallation = Output.InstallTextMate(registryOptions);
        textMateInstallation.SetGrammar(registryOptions.GetScopeByLanguageId(registryOptions.GetLanguageByExtension(".json").Id));

        DataContext = ApplicationServices.ServiceProvider.GetRequiredService<ExtendedInformationViewModel>();

        ThemeEngine.ApplyThemeToWindow(this, false);
    }
}