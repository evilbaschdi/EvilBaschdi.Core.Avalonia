using System.Reactive;
using EvilBaschdi.Core.Avalonia.Mvvm.Command;
using FluentAssertions;
using ReactiveUI;

namespace EvilBaschdi.Core.Avalonia.Tests;

public class ReactiveCommandUnitTaskTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(TestReactiveCommandUnitTask sut)
    {
        sut.Should().BeAssignableTo<IReactiveCommandUnitTask>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Command_ReturnsReactiveCommand(TestReactiveCommandUnitTask sut)
    {
        var command = sut.Command;

        command.Should().NotBeNull();
        command.Should().BeOfType<ReactiveCommand<Unit, Unit>>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void RunAsync_MethodCanBeOverridden(TestReactiveCommandUnitTask sut)
    {
        sut.RunAsyncCalled.Should().BeFalse();
        sut.RunAsyncCalled = true;
        sut.RunAsyncCalled.Should().BeTrue();
    }
}

public class TestReactiveCommandUnitTask : ReactiveCommandUnitTask
{
    public bool RunAsyncCalled { get; set; }
    public CancellationToken CancellationTokenReceived { get; set; }

    public override Task RunAsync(CancellationToken cancellationToken = default)
    {
        RunAsyncCalled = true;
        CancellationTokenReceived = cancellationToken;
        return Task.CompletedTask;
    }
}

public class TestReactiveCommandUnitTaskDefault : ReactiveCommandUnitTask
{
}
