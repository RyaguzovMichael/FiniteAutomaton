namespace FiniteAutomaton.Core;

public sealed class FiniteStateMachineBuilder<TState>
    where TState : Enum
{
    private readonly List<BuilderState<TState>> _states = []; 
        
    public FiniteStateMachine<TState> Build()
    {
        var machineStates = _states.Select(el => new MachineState<TState>(el.State));
        return new FiniteStateMachine<TState>(machineStates);
    }

    public void AddStage(TState state)
    {
        _states.Add(new BuilderState<TState>(state));
    }
}