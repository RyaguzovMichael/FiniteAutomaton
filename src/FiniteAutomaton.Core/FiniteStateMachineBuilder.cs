namespace FiniteAutomaton.Core;

public sealed class FiniteStateMachineBuilder<TState>
    where TState : Enum
{
    private readonly Dictionary<TState, BuilderState<TState>> _states = [];

    public void AddStage(TState state)
    {
        _states[state] = new BuilderState<TState>(state);
    }

    public FiniteStateMachine<TState> Build()
    {
        var machineStates = _states.Select(el => new MachineState<TState>(el.Value.State));
        return new FiniteStateMachine<TState>(machineStates);
    }
}
