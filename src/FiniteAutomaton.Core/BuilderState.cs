namespace FiniteAutomaton.Core;

internal sealed class BuilderState<TState>
    where TState : Enum
{
    public TState State { get; }
    
    public BuilderState(TState state)
    {
        State = state;
    }
}