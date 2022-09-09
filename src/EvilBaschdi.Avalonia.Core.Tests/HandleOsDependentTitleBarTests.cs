namespace EvilBaschdi.Avalonia.Core.Tests;

public class HandleOsDependentTitleBarTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(HandleOsDependentTitleBar).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(HandleOsDependentTitleBar sut)
    {
        sut.Should().BeAssignableTo<IHandleOsDependentTitleBar>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(HandleOsDependentTitleBar).GetMethods().Where(method => !method.IsAbstract & !method.Name.StartsWith("Run")));
    }
}