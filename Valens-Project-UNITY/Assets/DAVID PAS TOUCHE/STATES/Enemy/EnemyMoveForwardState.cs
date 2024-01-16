using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveForwardState : EnemyBaseState
{
    public EnemyMoveForwardState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void InStart()
    {
        Debug.Log("HORIMOVE");
    }

    public override void InUpdate(float deltaTime)
    {
        Move(Vector3.forward);
    }

    public override void OnExit()
    {

    }
}
