using Avalonia.Collections;

namespace EvilBaschdi.Core.Avalonia.DummyAppMvvm.ViewModels.Internal;

/// <inheritdoc cref="IWritableValue{T}" />
/// <inheritdoc cref="ICachedValue{T}" />
public interface IConfigureDataGridCollectionView : IWritableValue<DataGridCollectionView>, ICachedValue<DataGridCollectionView>;