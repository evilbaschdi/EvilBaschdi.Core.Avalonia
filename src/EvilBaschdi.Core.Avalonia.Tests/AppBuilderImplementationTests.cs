using Avalonia;

namespace EvilBaschdi.Core.Avalonia.Tests;

public class AppBuilderImplementationTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(AppBuilderImplementation<Application>).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(AppBuilderImplementation<Application> sut)
    {
        sut.Should().BeAssignableTo<IAppBuilderImplementation>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(AppBuilderImplementation<Application>).GetMethods().Where(method => !method.IsAbstract));
    }
}