using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolSystem : MonoBehaviour
{
    PlayerSpawnTraces playerLastPos;
    EnemyDetectionSystem enemyNewDetectionSystem;
    public Transform[] patrolPoint;

    //public Transform targetPoint;
    public int patrolPointNumber;


    public Vector3 direction, startPos, endPos;

    public List<Transform> newPatrolPoint;

    private void Start()
    {
        enemyNewDetectionSystem = GetComponent<EnemyDetectionSystem>();
        playerLastPos = FindObjectOfType<PlayerSpawnTraces>();
    }
    // Update is called once per frame
    void Update()
    {
        if(patrolPointNumber == patrolPoint.Length)
        {
            patrolPointNumber = 0;
        }
    }

    public void Patrol()
    {
        if(enemyNewDetectionSystem.isInDetectionRange)
        {
        }

        else
        {

            endPos = patrolPoint[patrolPointNumber].position;
            transform.position = endPos;
            patrolPointNumber++;
        }
    }
}
