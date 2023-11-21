using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveLeftState : EnemyBaseState
{
    public EnemyMoveLeftState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void InStart()
    {
    }

    public override void InUpdate(float deltaTime)
    {
        Move(Vector3.left);
    }

    public override void OnExit()
    {
    }
}
