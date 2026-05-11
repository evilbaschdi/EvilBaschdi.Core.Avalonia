using EvilBaschdi.Core.Avalonia.Themes;

namespace EvilBaschdi.Core.Avalonia.Tests.Themes;

public class PlatformThemeColorProviderTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(PlatformThemeColorProvider).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(PlatformThemeColorProvider sut)
    {
        sut.Should().BeAssignableTo<IThemeColorProvider>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(PlatformThemeColorProvider).GetMethods().Where(method => !method.IsAbstract));
    }
}