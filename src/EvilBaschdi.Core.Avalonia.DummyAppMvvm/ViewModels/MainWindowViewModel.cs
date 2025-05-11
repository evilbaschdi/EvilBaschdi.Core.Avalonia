using System.Reactive;
using Avalonia.Collections;
using EvilBaschdi.Core.Avalonia.DummyAppMvvm.Models;
using EvilBaschdi.Core.Avalonia.DummyAppMvvm.ViewModels.Internal;
using ReactiveUI;

// ReSharper disable UnusedMember.Global

namespace EvilBaschdi.Core.Avalonia.DummyAppMvvm.ViewModels;

/// <inheritdoc cref="IMainWindowViewModel" />
/// <inheritdoc cref="ViewModelBase" />
public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
{
    private readonly IConfigureDataGridCollectionView _configureDataGridCollectionView;
    private readonly ICurrentItem _currentItem;
    private readonly IShowExtendedInformation _showExtendedInformation;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="configureDataGridCollectionView"></param>
    /// <param name="currentItem"></param>
    /// <param name="showExtendedInformation"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public MainWindowViewModel([NotNull] IConfigureDataGridCollectionView configureDataGridCollectionView,
                               [NotNull] ICurrentItem currentItem,
                               [NotNull] IShowExtendedInformation showExtendedInformation)
    {
        _configureDataGridCollectionView = configureDataGridCollectionView ?? throw new ArgumentNullException(nameof(configureDataGridCollectionView));
        _currentItem = currentItem ?? throw new ArgumentNullException(nameof(currentItem));
        _showExtendedInformation = showExtendedInformation ?? throw new ArgumentNullException(nameof(showExtendedInformation));

        Run();
    }

    /// <summary>
    ///     Binding
    /// </summary>
    public DataGridCollectionView DataGridCollectionViewCountries
    {
        get => _configureDataGridCollectionView.Value;
        set => _configureDataGridCollectionView.Value = value;
    }

    /// <summary>
    /// </summary>
    public Country SelectedCountry
    {
        get => _currentItem.Value;
        set => _currentItem.Value = value;
    }

    /// <summary>
    /// </summary>
    public ReactiveCommand<Unit, Task> ShowExtendedInformationCommand { get; set; }

    /// <inheritdoc />
    public void Run()
    {
        ShowExtendedInformationCommand = _showExtendedInformation.Command;
    }
}