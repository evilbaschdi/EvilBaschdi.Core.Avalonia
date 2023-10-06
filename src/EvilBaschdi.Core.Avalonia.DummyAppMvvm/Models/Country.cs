// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local

// ReSharper disable UnusedMember.Global

namespace EvilBaschdi.Core.Avalonia.DummyAppMvvm.Models;

public class Country(string name, string region, int population, int area, double density, double coast, double? migration,
                     double? infantMorality, int gdp, double? literacy, double? phones, double? birth, double? death)
{
    //Square Miles
    public int Area { get; private set; } = area;

    public double? BirthRate { get; private set; } = birth;

    //Coast / Area
    public double CoastLine { get; private set; } = coast;
    public double? DeathRate { get; private set; } = death;

    public int Gdp { get; private set; } = gdp;

    //per 1000 births
    public double? InfantMortality { get; private set; } = infantMorality;
    public double? LiteracyPercent { get; private set; } = literacy;
    public string Name { get; private set; } = name;

    public double? NetMigration { get; private set; } = migration;

    //per 1000
    public double? Phones { get; private set; } = phones;

    public int Population { get; private set; } = population;

    //Per Square Mile
    public double PopulationDensity { get; private set; } = density;
    public string Region { get; private set; } = region;
}