using EvilBaschdi.Core.Avalonia.DummyAppMvvm.Models;

namespace EvilBaschdi.Core.Avalonia.DummyAppMvvm.ViewModels;

/// <inheritdoc cref="ViewModelBase" />
/// <summary>
///     Constructor
/// </summary>
public class ExtendedInformationViewModel(
    [NotNull] ICurrentItem currentItem) : ViewModelBase
{
    private readonly ICurrentItem _currentItem = currentItem ?? throw new ArgumentNullException(nameof(currentItem));

    #region Properties

    /// <summary>
    ///     Binding
    /// </summary>
    public Country SelectedCountry
    {
        get => _currentItem.Value;
        set => _currentItem.Value = value;
    }

    #endregion Properties
}