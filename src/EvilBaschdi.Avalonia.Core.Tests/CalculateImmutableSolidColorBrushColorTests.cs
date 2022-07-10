namespace EvilBaschdi.Avalonia.Core.Tests;

public class CalculateImmutableSolidColorBrushColorTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(CalculateImmutableSolidColorBrushColor).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(CalculateImmutableSolidColorBrushColor sut)
    {
        sut.Should().BeAssignableTo<ICalculateImmutableSolidColorBrushColor>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(CalculateImmutableSolidColorBrushColor).GetMethods().Where(method => !method.IsAbstract));
    }
}