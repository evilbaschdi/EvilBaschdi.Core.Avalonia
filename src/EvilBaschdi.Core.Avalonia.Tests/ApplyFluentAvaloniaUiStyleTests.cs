namespace EvilBaschdi.Core.Avalonia.Tests;

public class ApplyFluentAvaloniaUiStyleTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(ApplyFluentAvaloniaUiStyle).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(ApplyFluentAvaloniaUiStyle sut)
    {
        sut.Should().BeAssignableTo<IApplyFluentAvaloniaUiStyle>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(ApplyFluentAvaloniaUiStyle).GetMethods().Where(method => !method.IsAbstract));
    }
}