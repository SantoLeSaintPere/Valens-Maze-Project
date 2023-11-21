using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCalculatedMovement : MonoBehaviour
{
    EnemyWallDetector enemyWallDetector;
    public Transform target;

    public float xPos, zPos;
    public Vector3 direction;

    public bool canGoVerti;
    public bool goForward, goBack,goLeft, goRight;

    public Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        enemyWallDetector = GetComponent<EnemyWallDetector>();

        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        direction = target.position - transform.position;
        xPos = direction.x;
        zPos = direction.z;


        if(enemyWallDetector.isLeftWalles || enemyWallDetector.isRightWalled)
        {
            canGoVerti = true;
        }

        else
        {
            canGoVerti = transform.position.x == target.position.x;
        }


        CheckHorizontalDir();
        CheckVerticalDir();
    }

    private void CheckVerticalDir()
    {
        if (zPos > 0)
        {
            goForward = true;
            goBack = false;
        }

        else
        {
            goForward = false;
            goBack = true;
        }

    }

    private void CheckHorizontalDir()
    {
        if (xPos > 0)
        {
            goLeft = false;
            goRight = true;
        }

        else
        {
            goLeft = true;
            goRight = false;
        }
    }
}
