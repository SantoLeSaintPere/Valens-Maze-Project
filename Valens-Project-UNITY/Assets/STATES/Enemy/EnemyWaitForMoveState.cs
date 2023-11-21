using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyWaitForMoveState : EnemyBaseState
{
    float timer;
    public EnemyWaitForMoveState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void InStart()
    {
        Debug.Log("CHECK");
    }

    public override void InUpdate(float deltaTime)
    {
        if(stateMachine.inputReader.intputcontrols.Enemy.ACTION.WasPerformedThisFrame() && stateMachine.detectionSystem.isInDetectionRange)
        {
            if (stateMachine.transform.position.x != stateMachine.enemyCalcultedMove.target.position.x && !stateMachine.enemyCalcultedMove.canGoVerti)
            {
                if(!stateMachine.wallCheck.isLeftWalles && stateMachine.enemyCalcultedMove.goLeft)
                {
                    stateMachine.NextState(new EnemyMoveLeftState(stateMachine));
                }

                if (!stateMachine.wallCheck.isRightWalled && stateMachine.enemyCalcultedMove.goRight)
                {
                    stateMachine.NextState(new EnemyMoveRightState(stateMachine));
                }
            }

            if (stateMachine.transform.position.z != stateMachine.enemyCalcultedMove.target.position.z && stateMachine.enemyCalcultedMove.canGoVerti)
            {
                if (!stateMachine.wallCheck.isFrontWalled && stateMachine.enemyCalcultedMove.goForward)
                {
                    stateMachine.NextState(new EnemyMoveForwardState(stateMachine));
                }

                if (!stateMachine.wallCheck.isBackWalled && stateMachine.enemyCalcultedMove.goBack)
                {
                    stateMachine.NextState(new EnemyMoveBack(stateMachine));
                }
            }
        }
    }

    public override void OnExit()
    {
    }
}
