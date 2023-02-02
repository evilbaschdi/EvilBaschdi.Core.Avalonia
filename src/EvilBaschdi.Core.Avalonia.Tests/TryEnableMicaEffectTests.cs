namespace EvilBaschdi.Core.Avalonia.Tests;

public class TryEnableMicaEffectTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(TryEnableMicaEffect).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(TryEnableMicaEffect sut)
    {
        sut.Should().BeAssignableTo<ITryEnableMicaEffect>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(TryEnableMicaEffect).GetMethods().Where(method => !method.IsAbstract));
    }
}