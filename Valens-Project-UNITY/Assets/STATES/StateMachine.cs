using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    State currentState;

    private void Start()
    {
        //currentState.InStart();
    }

    private void Update()
    {
        currentState.InUpdate(Time.deltaTime);
    }

    public void NextState(State nextState)
    {
        currentState?.OnExit();
        currentState = nextState;
        currentState?.InStart();
    }

}
