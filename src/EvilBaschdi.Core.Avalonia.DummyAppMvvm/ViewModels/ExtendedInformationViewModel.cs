using System;
using EvilBaschdi.Core.Avalonia.DummyAppMvvm.Models;
using JetBrains.Annotations;

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

    /// <summary>
    /// </summary>

    [CanBeNull]
    public string SelectedCountryAsString => SelectedCountry?.ToString() ?? "CurrentItem is NULL";

    #endregion Properties
}