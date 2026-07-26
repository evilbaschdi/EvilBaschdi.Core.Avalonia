using EvilBaschdi.Core.Avalonia.Mvvm.Command;
using ReactiveUI;
using ReactiveUI.Primitives;

namespace EvilBaschdi.Core.Avalonia.Tests;

public class ReactiveCommandRxVoidRunTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(TestReactiveCommandRxVoidRun sut)
    {
        sut.Should().BeAssignableTo<IReactiveCommandRxVoidRun>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Command_ReturnsReactiveCommand(TestReactiveCommandRxVoidRun sut)
    {
        var command = sut.Command;

        command.Should().NotBeNull();
        command.Should().BeOfType<ReactiveCommand<RxVoid, RxVoid>>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Run_MethodCanBeOverridden(TestReactiveCommandRxVoidRun sut)
    {
        sut.RunCalled.Should().BeFalse();
        sut.RunCalled = true;
        sut.RunCalled.Should().BeTrue();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Command_Property_IsNotNull(TestReactiveCommandRxVoidRun sut)
    {
        sut.Command.Should().NotBeNull();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Run_MethodCanBeCalledMultipleTimes(TestReactiveCommandRxVoidRun sut)
    {
        sut.RunCalled = false;

        sut.Run();
        sut.RunCalled.Should().BeTrue();

        sut.RunCalled = false;
        sut.Run();
        sut.RunCalled.Should().BeTrue();
    }

    [Fact]
    public void Command_ReturnsSameInstanceWhenCalledMultipleTimes()
    {
        var sut = new TestReactiveCommandRxVoidRunDefault();

        var command1 = sut.Command;
        var command2 = sut.Command;

        command1.Should().BeSameAs(command2);
    }

    [Fact]
    public void Run_DefaultImplementationThrows()
    {
        var sut = new TestReactiveCommandRxVoidRunDefault();

        var act = () => sut.Run();

        act.Should().Throw<NotImplementedException>();
    }
}

public class TestReactiveCommandRxVoidRun : ReactiveCommandRxVoidRun
{
    public bool RunCalled { get; set; }

    public override void Run()
    {
        RunCalled = true;
    }
}

public class TestReactiveCommandRxVoidRunDefault : ReactiveCommandRxVoidRun
{
}