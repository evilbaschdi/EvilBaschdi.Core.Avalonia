namespace EvilBaschdi.Avalonia.Core.Tests;

public class OnRequestedThemeChangedTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(OnRequestedThemeChanged).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(OnRequestedThemeChanged sut)
    {
        sut.Should().BeAssignableTo<IOnRequestedThemeChanged>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(OnRequestedThemeChanged).GetMethods().Where(method => !method.IsAbstract));
    }
}