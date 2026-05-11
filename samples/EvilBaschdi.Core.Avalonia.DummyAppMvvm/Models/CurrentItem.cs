namespace EvilBaschdi.Core.Avalonia.DummyAppMvvm.Models;

/// <inheritdoc cref="ICurrentItem" />
public class CurrentItem : CachedWritableValue<Country>, ICurrentItem
{
    private Country _country;

    /// <inheritdoc />
    protected override Country NonCachedValue => _country;

    /// <inheritdoc />
    protected override void SaveValue([NotNull] Country country)
    {
        _country = country;
    }
}