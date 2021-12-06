using UnityEngine;

public class StateMachine : MonoBehaviour
{
    //
    public State CurrentState { get; private set; }

    //Initialization of state machine
    public void Initialize(State startingState)
    {
        CurrentState = startingState;
        StartCoroutine(CurrentState.EnterState());
    }

    //
    public void ChangeState(State newState)
    {
        CurrentState = newState;
        StartCoroutine(CurrentState.EnterState());
    }  
}
