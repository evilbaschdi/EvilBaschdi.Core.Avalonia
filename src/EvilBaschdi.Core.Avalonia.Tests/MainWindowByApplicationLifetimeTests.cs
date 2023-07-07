namespace EvilBaschdi.Core.Avalonia.Tests;

public class MainWindowByApplicationLifetimeTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(MainWindowByApplicationLifetime).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(MainWindowByApplicationLifetime sut)
    {
        sut.Should().BeAssignableTo<IMainWindowByApplicationLifetime>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(MainWindowByApplicationLifetime).GetMethods().Where(method => !method.IsAbstract));
    }
}