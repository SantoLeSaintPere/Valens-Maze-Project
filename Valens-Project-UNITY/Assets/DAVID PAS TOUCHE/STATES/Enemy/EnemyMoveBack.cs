using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveBack : EnemyBaseState
{
    public EnemyMoveBack(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void InStart()
    {
    }

    public override void InUpdate(float deltaTime)
    {
        Move(Vector3.back);
    }

    public override void OnExit()
    {
    }
}
