using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundWallDetector : MonoBehaviour
{
    public float range = 1;

    public Transform bodyTr;
    public Transform groundDetectorTr;
    public LayerMask groundLayer;

    public bool isGrounded, isWalled;

    // Update is called once per frame
    void Update()
    {
        CheckWall();
        CheckGround();
    }

    void CheckGround()
    {
        RaycastHit hit;
        Debug.DrawRay(groundDetectorTr.position , Vector3.down * range, Color.green);
        isGrounded = Physics.Raycast(groundDetectorTr.position , Vector3.down, out hit, range, groundLayer);

    }

    void CheckWall()
    {

        RaycastHit hit;
        Debug.DrawRay(transform.position,Vector3.forward * range, Color.red);
        isWalled = Physics.Raycast(bodyTr.position, bodyTr.forward, out hit, range, groundLayer);
    }
}
