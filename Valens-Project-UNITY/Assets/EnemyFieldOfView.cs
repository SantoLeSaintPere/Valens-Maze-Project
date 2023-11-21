using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFieldOfView : MonoBehaviour
{
    //[HideInInspector]
    public bool isPlayerDetected;
    public LayerMask wallLayer;
    public float fieldOfViewRange = 1;

    public Transform target;
    Vector3 dir;
    public Transform playerWallDetector;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        dir = target.position - playerWallDetector.position;
        fieldOfViewRange = dir.magnitude;
        playerWallDetector.transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
        CheckDetectionRange();
    }

    void CheckDetectionRange()
    {
        Debug.DrawRay(playerWallDetector.position, dir * fieldOfViewRange, Color.red);
        if (Physics.Raycast(playerWallDetector.position, dir, fieldOfViewRange, wallLayer))
        {
            isPlayerDetected = false;
        }

        else
        {
            isPlayerDetected = true;
        }
    }
}
