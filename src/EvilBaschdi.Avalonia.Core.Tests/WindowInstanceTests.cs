namespace EvilBaschdi.Avalonia.Core.Tests;

public class WindowInstanceTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(WindowInstance).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(WindowInstance sut)
    {
        sut.Should().BeAssignableTo<IWindowInstance>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(WindowInstance).GetMethods().Where(method => !method.IsAbstract));
    }
}