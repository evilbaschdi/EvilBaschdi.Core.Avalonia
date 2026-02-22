using System.Reactive;
using EvilBaschdi.Core.Avalonia.Mvvm.Command;
using FluentAssertions;
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
