using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public abstract class EnemyBaseState : State
{
    protected EnemyStateMachine stateMachine;

    protected EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    public void Move(Vector3 dir)
    {
        Vector3 pos = stateMachine.transform.position;
        Vector3 endPos = stateMachine.transform.position + dir;
        stateMachine.transform.position = endPos;
        stateMachine.NextState(new EnemyIdleState(stateMachine));
    }

    protected void  NoMove()
    {
        stateMachine.transform.Translate(Vector3.zero);
    }
}
