namespace UnitTests;

public class CreateMachineTests
{
    [Fact]
    public void InitializeMachineReturnExemplarOfMachine()
    {
        // Arrange
        var builder = new FiniteStateMachineBuilder<TestStates>();

        // Act
        var machine = builder.Build();

        // Assert
        Assert.NotNull(machine);
        Assert.Equal(typeof(FiniteStateMachine<TestStates>), machine.GetType());
        Assert.Null(machine.Current());
    }

    [Fact]
    public void InitializeMachineWithOneStage()
    {
        // Arrange
        var builder = new FiniteStateMachineBuilder<TestStates>();

        // Act
        builder.AddStage(TestStates.Start);
        var machine = builder.Build();

        // Assert
        Assert.Equal(1, machine.GetInfo().StagesCount);
        Assert.NotNull(machine.Current());
        Assert.Equal(TestStates.Start, machine.Current()!.State);
    }

    private enum TestStates
    {
        Start,
        End
    }
}