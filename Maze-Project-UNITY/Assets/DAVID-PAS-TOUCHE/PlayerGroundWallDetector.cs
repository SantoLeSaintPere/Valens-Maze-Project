using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundWallDetector : MonoBehaviour
{
    MovementTest movementTest;

    public float range;

    public Transform wallDetectorTr;
    public Transform groundDetectorTr;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        movementTest = GetComponent<MovementTest>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckWall();
        CheckGround();
    }

    private void CheckGround()
    {
        RaycastHit hit;
        Debug.DrawRay(groundDetectorTr.position , Vector3.down * range, Color.green);
        bool isGrounded = Physics.Raycast(groundDetectorTr.position , Vector3.down, out hit, range, groundLayer);

        if(isGrounded)
        {
            movementTest.canMove = true;
        }

        else
        {
            movementTest.canMove= false;
        }

    }

    void CheckWall()
    {

        RaycastHit hit;
        Debug.DrawRay(wallDetectorTr.position,Vector3.forward * range, Color.red);
        bool noWall = Physics.Raycast(wallDetectorTr.position, Vector3.forward, out hit, range);

        if (noWall)
        {
            movementTest.canMove = false;
        }

        else
        {
            movementTest.canMove = true;
        }
    }
}
