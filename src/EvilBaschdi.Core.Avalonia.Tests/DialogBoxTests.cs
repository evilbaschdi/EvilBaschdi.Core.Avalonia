using Avalonia.Controls;

namespace EvilBaschdi.Core.Avalonia.Tests;

public class DialogBoxTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(DialogBox).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(DialogBox sut)
    {
        sut.Should().BeAssignableTo<Window>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(DialogBox).GetMethods().Where(method => !method.IsAbstract));
    }
}