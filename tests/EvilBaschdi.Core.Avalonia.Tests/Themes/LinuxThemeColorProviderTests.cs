using EvilBaschdi.Core.Avalonia.Themes;

namespace EvilBaschdi.Core.Avalonia.Tests.Themes;

public class LinuxThemeColorProviderTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(LinuxThemeColorProvider).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(LinuxThemeColorProvider sut)
    {
        sut.Should().BeAssignableTo<IThemeColorProvider>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(LinuxThemeColorProvider).GetMethods().Where(method => !method.IsAbstract));
    }
}