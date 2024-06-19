namespace FiniteAutomaton.Core;

internal sealed class BuilderState<TState>
    where TState : Enum
{
    public BuilderState(TState state)
    {
        State = state;
    }

    public TState State { get; }
}