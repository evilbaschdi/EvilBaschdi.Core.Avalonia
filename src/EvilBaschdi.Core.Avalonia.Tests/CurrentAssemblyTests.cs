namespace EvilBaschdi.Core.Avalonia.Tests;

public class CurrentAssemblyTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(CurrentAssembly).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(CurrentAssembly sut)
    {
        sut.Should().BeAssignableTo<ICurrentAssembly>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(CurrentAssembly).GetMethods().Where(method => !method.IsAbstract));
    }
}