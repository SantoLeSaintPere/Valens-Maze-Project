using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    [HideInInspector]
    public EnemyCalculatedMovement enemyCalcultedMove;
    [HideInInspector]
    public EnemyDetectionSystem detectionSystem;
    [HideInInspector]
    public EnemyInputReader inputReader;
    [HideInInspector]
    public EnemyWallDetector wallCheck;
    [HideInInspector]
    public EnemyFieldOfView fieldOfView;

    public GameObject lookingSign;

    public float timeToResetPos = 5;

    // Start is called before the first frame update
    void Start()
    {
        lookingSign.SetActive(false);

        enemyCalcultedMove = GetComponent<EnemyCalculatedMovement>();
        detectionSystem = GetComponent<EnemyDetectionSystem>();
        inputReader = GetComponent<EnemyInputReader>();
        wallCheck = GetComponent<EnemyWallDetector>();
        fieldOfView = GetComponent<EnemyFieldOfView>();
        NextState(new EnemyIdleState(this));
    }
}
