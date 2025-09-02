using EvilBaschdi.Core.Avalonia.DummyAppMvvm.Views;
using EvilBaschdi.Core.Avalonia.Mvvm.Command;
using Microsoft.Extensions.DependencyInjection;

namespace EvilBaschdi.Core.Avalonia.DummyAppMvvm.ViewModels.Internal;

/// <inheritdoc cref="IShowExtendedInformation" />
/// <inheritdoc cref="ReactiveCommandUnitRun" />
public class ShowExtendedInformation : ReactiveCommandUnitTask, IShowExtendedInformation
{
    private readonly IMainWindowByApplicationLifetime _mainWindowByApplicationLifetime;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="mainWindowByApplicationLifetime"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public ShowExtendedInformation([NotNull] IMainWindowByApplicationLifetime mainWindowByApplicationLifetime)
    {
        _mainWindowByApplicationLifetime = mainWindowByApplicationLifetime ?? throw new ArgumentNullException(nameof(mainWindowByApplicationLifetime));
    }

    /// <inheritdoc />
    public override async Task RunAsync(CancellationToken cancellationToken = default)
    {
        var mainWindow = _mainWindowByApplicationLifetime.Value;
        var extendedInformationDialog = App.ServiceProvider.GetRequiredService<ExtendedInformation>();

        if (mainWindow != null)
        {
            await extendedInformationDialog.ShowDialog(mainWindow);
        }
    }
}