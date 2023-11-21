using UnityEngine;
public class EnemyResetPositionState : EnemyBaseState
{
    float timer;
    public EnemyResetPositionState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void InStart()
    {
        timer = 0;
        stateMachine.lookingSign.SetActive(true);
    }

    public override void InUpdate(float deltaTime)
    {
        timer += deltaTime;

        if(timer >= stateMachine.timeToResetPos)
        {
            stateMachine.transform.position = stateMachine.enemyCalcultedMove.originalPos;
            stateMachine.NextState(new EnemyIdleState(stateMachine));
        }
    }

    public override void OnExit()
    {
        stateMachine.lookingSign.SetActive(false);
    }
}