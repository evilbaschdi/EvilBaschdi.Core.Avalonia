using Avalonia.Controls;

namespace EvilBaschdi.Core.Avalonia.Tests;

public class MessageBoxTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(MessageBox).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(MessageBox sut)
    {
        sut.Should().BeAssignableTo<Window>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(MessageBox).GetMethods().Where(method => !method.IsAbstract));
    }
}