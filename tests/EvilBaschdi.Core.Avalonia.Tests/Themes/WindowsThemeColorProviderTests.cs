using EvilBaschdi.Core.Avalonia.Themes;

namespace EvilBaschdi.Core.Avalonia.Tests.Themes;

public class WindowsThemeColorProviderTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(WindowsThemeColorProvider).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(WindowsThemeColorProvider sut)
    {
        sut.Should().BeAssignableTo<IThemeColorProvider>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(WindowsThemeColorProvider).GetMethods().Where(method => !method.IsAbstract));
    }
}