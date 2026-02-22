using Avalonia;

namespace EvilBaschdi.Core.Avalonia.Tests;

// ReSharper disable once InconsistentNaming
public class AppBuilderImplementationToUseReactiveUIWithMicrosoftDependencyResolverTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(AppBuilderImplementationToUseReactiveUIWithMicrosoftDependencyResolver<>).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(AppBuilderImplementationToUseReactiveUIWithMicrosoftDependencyResolver<Application> sut)
    {
        sut.Should().BeAssignableTo<IAppBuilderImplementationToUseReactiveUIWithMicrosoftDependencyResolver>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(AppBuilderImplementationToUseReactiveUIWithMicrosoftDependencyResolver<>).GetMethods().Where(method => !method.IsAbstract));
    }
}