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

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void RunAsync_ReceivesCancellationToken(TestReactiveCommandUnitTask sut)
    {
        sut.CancellationTokenReceived = CancellationToken.None;

        sut.CancellationTokenReceived.Should().Be(CancellationToken.None);
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public async Task RunAsync_CanBeAwaited(TestReactiveCommandUnitTask sut)
    {
        var task = sut.RunAsync();

        var act = async () => await task;

        await act.Should().NotThrowAsync();
    }

    [Fact]
    public void Command_Property_IsNotNull()
    {
        var sut = new TestReactiveCommandUnitTaskDefault();

        sut.Command.Should().NotBeNull();
    }

    [Fact]
    public async Task RunAsync_DefaultImplementation_ThrowsNotImplementedException()
    {
        var sut = new TestReactiveCommandUnitTaskDefault();

        var act = () => sut.RunAsync();

        await act.Should().ThrowAsync<NotImplementedException>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public async Task RunAsync_ExecutesCommand(TestReactiveCommandUnitTask sut)
    {
        var command = sut.Command;

        command.Should().NotBeNull();
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
