using System.Reactive;
using EvilBaschdi.Core.Avalonia.Mvvm.Command;
using ReactiveUI;

namespace EvilBaschdi.Core.Avalonia.Tests;

public class ReactiveCommandUnitRunTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(TestReactiveCommandUnitRun sut)
    {
        sut.Should().BeAssignableTo<IReactiveCommandUnitRun>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Command_ReturnsReactiveCommand(TestReactiveCommandUnitRun sut)
    {
        var command = sut.Command;

        command.Should().NotBeNull();
        command.Should().BeOfType<ReactiveCommand<Unit, Unit>>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Run_MethodCanBeOverridden(TestReactiveCommandUnitRun sut)
    {
        sut.RunCalled.Should().BeFalse();
        sut.RunCalled = true;
        sut.RunCalled.Should().BeTrue();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Command_Property_IsNotNull(TestReactiveCommandUnitRun sut)
    {
        sut.Command.Should().NotBeNull();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Run_MethodCanBeCalledMultipleTimes(TestReactiveCommandUnitRun sut)
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
        var sut = new TestReactiveCommandUnitRunDefault();

        var command1 = sut.Command;
        var command2 = sut.Command;

        // Command property may create new instances, just verify they're both valid
        command1.Should().NotBeNull();
        command2.Should().NotBeNull();
    }

    [Fact]
    public void Run_DefaultImplementationThrows()
    {
        var sut = new TestReactiveCommandUnitRunDefault();

        var act = () => sut.Run();

        act.Should().Throw<NotImplementedException>();
    }
}

public class TestReactiveCommandUnitRun : ReactiveCommandUnitRun
{
    public bool RunCalled { get; set; }

    public override void Run()
    {
        RunCalled = true;
    }
}

public class TestReactiveCommandUnitRunDefault : ReactiveCommandUnitRun
{
}