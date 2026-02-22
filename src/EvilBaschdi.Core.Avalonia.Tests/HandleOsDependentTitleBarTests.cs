using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Platform;
using FluentAssertions;

namespace EvilBaschdi.Core.Avalonia.Tests;

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

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Run_DoesNotThrow(HandleOsDependentTitleBar sut)
    {
        var act = () => sut.Run();

        act.Should().NotThrow();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void RunFor_WithNullWindow_ThrowsArgumentNullException(HandleOsDependentTitleBar sut)
    {
        var act = () => sut.RunFor(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void Run_IsIdempotent()
    {
        var sut = new HandleOsDependentTitleBar();

        var act1 = () => sut.Run();
        var act2 = () => sut.Run();

        act1.Should().NotThrow();
        act2.Should().NotThrow();
    }
}