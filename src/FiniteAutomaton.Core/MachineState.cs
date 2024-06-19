namespace FiniteAutomaton.Core;

public sealed class MachineState<TState>
    where TState : Enum
{
    public MachineState(TState state)
    {
        State = state;
    }

    public TState State { get; }
}