using Avalonia.Controls;
using AvaloniaEdit.TextMate;
using EvilBaschdi.Core.Avalonia.DummyAppMvvm.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using TextMateSharp.Grammars;

namespace EvilBaschdi.Core.Avalonia.DummyAppMvvm.Views;

/// <inheritdoc />
public partial class ExtendedInformation : Window
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

        ApplyLayout();

        var extendedInformationViewModel = App.ServiceProvider.GetRequiredService<ExtendedInformationViewModel>();
        DataContext = extendedInformationViewModel;

        Output.Text = extendedInformationViewModel.SelectedCountry?.ToString() ?? "CurrentItem is NULL";
    }

    private void ApplyLayout()
    {
        var handleOsDependentTitleBar = App.ServiceProvider?.GetRequiredService<IHandleOsDependentTitleBar>();
        handleOsDependentTitleBar?.RunFor(this);

        var applicationLayout = App.ServiceProvider?.GetRequiredService<IApplicationLayout>();
        applicationLayout?.RunFor((this, true, false));
    }
}