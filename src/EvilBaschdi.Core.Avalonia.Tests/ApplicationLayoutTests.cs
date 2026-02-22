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

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void RunFor_TupleParameter_DoesNotThrow(ApplicationLayout sut)
    {
        var act = () => sut.RunFor((Center: true, ResizeWithBorder400: false));

        act.Should().NotThrow();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void RunFor_TupleParameter_WithCenterTrue(ApplicationLayout sut)
    {
        var act = () => sut.RunFor((Center: true, ResizeWithBorder400: false));
        act.Should().NotThrow();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void RunFor_TupleParameter_WithCenterFalse(ApplicationLayout sut)
    {
        var act = () => sut.RunFor((Center: false, ResizeWithBorder400: true));
        act.Should().NotThrow();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void RunFor_TupleParameter_ResizeFalse(ApplicationLayout sut)
    {
        var act = () => sut.RunFor((Center: true, ResizeWithBorder400: false));
        act.Should().NotThrow();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void RunFor_TupleParameter_BothTrue(ApplicationLayout sut)
    {
        var act = () => sut.RunFor((Center: true, ResizeWithBorder400: true));
        act.Should().NotThrow();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void RunFor_TupleParameter_BothFalse(ApplicationLayout sut)
    {
        var act = () => sut.RunFor((Center: false, ResizeWithBorder400: false));
        act.Should().NotThrow();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void RunFor_WithBothTrueMultipleTimes(ApplicationLayout sut)
    {
        var act1 = () => sut.RunFor((Center: true, ResizeWithBorder400: true));
        var act2 = () => sut.RunFor((Center: true, ResizeWithBorder400: true));

        act1.Should().NotThrow();
        act2.Should().NotThrow();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void RunFor_WithVariousCombinations(ApplicationLayout sut)
    {
        sut.RunFor((Center: false, ResizeWithBorder400: false));
        sut.RunFor((Center: true, ResizeWithBorder400: false));
        sut.RunFor((Center: false, ResizeWithBorder400: true));
        sut.RunFor((Center: true, ResizeWithBorder400: true));
    }
}