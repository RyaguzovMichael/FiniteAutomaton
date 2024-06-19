namespace FiniteAutomaton.Core;

public sealed class FiniteStateMachine<TState>
    where TState : Enum
{
    private readonly List<MachineState<TState>> _states;
    private MachineState<TState>? _current;

    public FiniteStateMachine(IEnumerable<MachineState<TState>> states)
    {
        _states = states.ToList();
        _current = _states.FirstOrDefault();
    }

    public StateMachineInfo GetInfo()
    {
        return new StateMachineInfo()
        {
            StagesCount = _states.Count
        };
    }

    public MachineState<TState>? Current()
    {
        return _current;
    }
}
