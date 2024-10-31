using Avalonia.Collections;
using EvilBaschdi.Core.Avalonia.DummyAppMvvm.Models;

namespace EvilBaschdi.Core.Avalonia.DummyAppMvvm.ViewModels.Internal;

/// <inheritdoc cref="IConfigureDataGridCollectionView" />
public class ConfigureDataGridCollectionView
    : CachedWritableValue<DataGridCollectionView>, IConfigureDataGridCollectionView
{
    private DataGridCollectionView _dataGridCollectionView;

    /// <inheritdoc />
    protected override DataGridCollectionView NonCachedValue
    {
        get
        {
            _dataGridCollectionView = new DataGridCollectionView(Countries.Value)
                                      {
                                          GroupDescriptions =
                                          {
                                              new DataGridPathGroupDescription("Region")
                                          }
                                      };

            return _dataGridCollectionView;
        }
    }

    /// <inheritdoc />
    protected override void SaveValue(DataGridCollectionView value)
    {
        _dataGridCollectionView = value ?? throw new ArgumentNullException(nameof(value));
    }
}