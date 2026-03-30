using Avalonia.Controls;
using AvaloniaEdit.TextMate;
using EvilBaschdi.Core.Avalonia.Behaviors;
using EvilBaschdi.Core.Avalonia.DependencyInjection;
using EvilBaschdi.Core.Avalonia.DummyAppMvvm.ViewModels;
using EvilBaschdi.Core.Avalonia.Layout;
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

        var extendedInformationViewModel = ApplicationServices.ServiceProvider.GetRequiredService<ExtendedInformationViewModel>();
        DataContext = extendedInformationViewModel;

        Output.Text = extendedInformationViewModel.SelectedCountry?.ToString() ?? "CurrentItem is NULL";
        Opened += OnOpened;
    }

    private void OnOpened(object sender, EventArgs e)
    {
        var windowOpenedBehavior = ApplicationServices.ServiceProvider?.GetRequiredService<IWindowOpenedBehavior>();
        windowOpenedBehavior?.OnWindowOpened(this);
    }

    private void ApplyLayout()
    {
        //var handleOsDependentTitleBar = ApplicationServices.ServiceProvider?.GetRequiredService<IHandleOsDependentTitleBar>();
        //handleOsDependentTitleBar?.RunFor(this);

        var applicationLayout = ApplicationServices.ServiceProvider?.GetRequiredService<IApplicationLayout>();
        applicationLayout?.RunFor((this, true, false));
    }
}