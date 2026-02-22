using Avalonia;

namespace EvilBaschdi.Core.Avalonia.Tests;

// ReSharper disable once InconsistentNaming
public class AppBuilderImplementationToUseReactiveUITests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(AppBuilderImplementationToUseReactiveUI<>).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(AppBuilderImplementationToUseReactiveUI<Application> sut)
    {
        sut.Should().BeAssignableTo<IAppBuilderImplementationToUseReactiveUI>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(AppBuilderImplementationToUseReactiveUI<>).GetMethods().Where(method => !method.IsAbstract));
    }
}