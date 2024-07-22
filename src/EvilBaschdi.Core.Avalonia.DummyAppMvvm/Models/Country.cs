// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local

// ReSharper disable UnusedMember.Global

namespace EvilBaschdi.Core.Avalonia.DummyAppMvvm.Models;

/// <summary>
/// </summary>
/// <param name="name"></param>
/// <param name="region"></param>
/// <param name="population"></param>
/// <param name="area"></param>
/// <param name="density"></param>
/// <param name="coast"></param>
/// <param name="migration"></param>
/// <param name="infantMorality"></param>
/// <param name="gdp"></param>
/// <param name="literacy"></param>
/// <param name="phones"></param>
/// <param name="birth"></param>
/// <param name="death"></param>
public class Country(
    string name,
    string region,
    int population,
    int area,
    double density,
    double coast,
    double? migration,
    double? infantMorality,
    int gdp,
    double? literacy,
    double? phones,
    double? birth,
    double? death)
{
    /// <summary>
    ///     Square Miles
    /// </summary>
    public int Area { get; private set; } = area;

    /// <summary>
    /// </summary>
    public double? BirthRate { get; private set; } = birth;

    /// <summary>
    ///     Coast / Area
    /// </summary>
    public double CoastLine { get; private set; } = coast;

    /// <summary>
    /// </summary>
    public double? DeathRate { get; private set; } = death;

    /// <summary>
    /// </summary>
    public int Gdp { get; private set; } = gdp;

    /// <summary>
    ///     per 1000 births
    /// </summary>
    public double? InfantMortality { get; private set; } = infantMorality;

    /// <summary>
    /// </summary>
    public double? LiteracyPercent { get; private set; } = literacy;

    /// <summary>
    /// </summary>
    public string Name { get; private set; } = name;

    /// <summary>
    /// </summary>
    public double? NetMigration { get; private set; } = migration;

    /// <summary>
    ///     per 1000
    /// </summary>
    public double? Phones { get; private set; } = phones;

    /// <summary>
    /// </summary>
    public int Population { get; private set; } = population;

    /// <summary>
    ///     Per Square Mile
    /// </summary>
    public double PopulationDensity { get; private set; } = density;

    /// <summary>
    /// </summary>
    public string Region { get; private set; } = region;
}