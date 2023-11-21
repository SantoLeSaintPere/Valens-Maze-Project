using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void InStart()
    {
        Debug.Log("IDLE");
    }

    public override void InUpdate(float deltaTime)
    {
        if(stateMachine.detectionSystem.isInDetectionRange  && stateMachine.fieldOfView.isPlayerDetected)
        {
            stateMachine.NextState(new EnemyWaitForMoveState(stateMachine));
        }

        else
        {
            NoMove();
        }

        if(stateMachine.transform.position != stateMachine.enemyCalcultedMove.originalPos && !stateMachine.detectionSystem.isInDetectionRange)
        {
            stateMachine.NextState(new EnemyResetPositionState(stateMachine));
        }

    }

    public override void OnExit()
    {
    }
}
