namespace EvilBaschdi.Core.Avalonia.Tests;

public class ApplicationLayoutTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(ApplicationLayout).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(ApplicationLayout sut)
    {
        sut.Should().BeAssignableTo<IApplicationLayout>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(ApplicationLayout).GetMethods().Where(method => !method.IsAbstract & !method.Name.StartsWith("RunFor")));
    }
}