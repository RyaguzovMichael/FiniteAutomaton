namespace UnitTests;

public class CreateMachineTests
{
    public enum TestStates
    {
        Start,
        End
    }

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

    [Fact]
    public void AddToMachineTwoStageWithOneNameApplyOnlyLast()
    {
        // Arrange
        var builder = new FiniteStateMachineBuilder<TestStates>();

        // Act
        builder.AddStage(TestStates.Start);
        builder.AddStage(TestStates.Start);
        var machine = builder.Build();

        // Assert
        Assert.Equal(1, machine.GetInfo().StagesCount);
        Assert.NotNull(machine.Current());
        Assert.Equal(TestStates.Start, machine.Current()!.State);
    }

    [Theory]
    [InlineData(TestStates.Start, TestStates.End)]
    [InlineData(TestStates.End, TestStates.Start)]
    public void AddTwoDifferentStagesToMachineFirstDeclaredIsFirstStage(params TestStates[] states)
    {
        // Arrange
        var builder = new FiniteStateMachineBuilder<TestStates>();

        // Act
        foreach (var state in states) builder.AddStage(state);
        var machine = builder.Build();

        // Assert
        Assert.Equal(2, machine.GetInfo().StagesCount);
        Assert.Equal(states.First(), machine.Current()!.State);
    }
}
