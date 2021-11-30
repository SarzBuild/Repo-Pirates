using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
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
