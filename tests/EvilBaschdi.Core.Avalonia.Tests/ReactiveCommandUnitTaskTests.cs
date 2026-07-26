using EvilBaschdi.Core.Avalonia.Mvvm.Command;
using ReactiveUI;
using ReactiveUI.Primitives;

namespace EvilBaschdi.Core.Avalonia.Tests;

public class ReactiveCommandRxVoidTaskTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(TestReactiveCommandRxVoidTask sut)
    {
        sut.Should().BeAssignableTo<IReactiveCommandRxVoidTask>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Command_ReturnsReactiveCommand(TestReactiveCommandRxVoidTask sut)
    {
        var command = sut.Command;

        command.Should().NotBeNull();
        command.Should().BeOfType<ReactiveCommand<RxVoid, RxVoid>>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void RunAsync_MethodCanBeOverridden(TestReactiveCommandRxVoidTask sut)
    {
        sut.RunAsyncCalled.Should().BeFalse();
        sut.RunAsyncCalled = true;
        sut.RunAsyncCalled.Should().BeTrue();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void RunAsync_ReceivesCancellationToken(TestReactiveCommandRxVoidTask sut)
    {
        sut.CancellationTokenReceived = TestContext.Current.CancellationToken;

        sut.CancellationTokenReceived.Should().Be(TestContext.Current.CancellationToken);
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public async Task RunAsync_CanBeAwaited(TestReactiveCommandRxVoidTask sut)
    {
        var task = sut.RunAsync(TestContext.Current.CancellationToken);

        var act = async () => await task;

        await act.Should().NotThrowAsync();
    }

    [Fact]
    public void Command_ReturnsSameInstanceWhenCalledMultipleTimes()
    {
        var sut = new TestReactiveCommandRxVoidTaskDefault();

        var command1 = sut.Command;
        var command2 = sut.Command;

        command1.Should().BeSameAs(command2);
    }

    [Fact]
    public async Task RunAsync_DefaultImplementation_ThrowsNotImplementedException()
    {
        var sut = new TestReactiveCommandRxVoidTaskDefault();

        var act = () => sut.RunAsync();

        await act.Should().ThrowAsync<NotImplementedException>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public async Task RunAsync_ExecutesCommand(TestReactiveCommandRxVoidTask sut)
    {
        var command = sut.Command;

        command.Should().NotBeNull();
    }
}

public class TestReactiveCommandRxVoidTask : ReactiveCommandRxVoidTask
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

public class TestReactiveCommandRxVoidTaskDefault : ReactiveCommandRxVoidTask
{
}