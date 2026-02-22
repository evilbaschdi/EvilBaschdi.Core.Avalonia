using Avalonia;
using FluentAssertions;
using ReactiveUI.Builder;

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

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void ValueFor_WithNullAction_ThrowsArgumentNullException(AppBuilderImplementationToUseReactiveUI<Application> sut)
    {
        var act = () => sut.ValueFor(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void ValueFor_WithValidAction_ReturnsAppBuilder(AppBuilderImplementationToUseReactiveUI<Application> sut)
    {
        Action<ReactiveUIBuilder> action = _ => { };

        var result = sut.ValueFor(action);

        result.Should().NotBeNull();
    }
}