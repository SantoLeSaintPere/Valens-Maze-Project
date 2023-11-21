using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveRightState : EnemyBaseState
{
    public EnemyMoveRightState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void InStart()
    {
    }

    public override void InUpdate(float deltaTime)
    {
        Move(Vector3.right);
    }

    public override void OnExit()
    {
    }
}
