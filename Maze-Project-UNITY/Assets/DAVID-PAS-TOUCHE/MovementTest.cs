using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    PlayerInputReader inputReader;

    [Header("PLAYER BODY")]
    public float turnSpeed = 0.1f;
    public Transform playerBody;


    [Header("PLAYER MOVEMENT")]
    public Vector3 direction;
    public Vector3 startPos, endPos;
    public float moveTime = 0.2f;

    public bool canMove;
    bool isMoving;

    void Start()
    {
        inputReader = GetComponent<PlayerInputReader>();
        direction = Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInputs();
    }

    void CheckInputs()
    {
        if(inputReader.inputControls.Player.Up.WasPerformedThisFrame())
        {
            Quaternion newRot = Quaternion.Euler(0, 0, 0);

            playerBody.rotation = newRot;


            direction = Vector3.forward;
        }


        if (inputReader.inputControls.Player.Down.WasPerformedThisFrame())
        {
            Quaternion newRot = Quaternion.Euler(0, 180, 0);

            playerBody.rotation = newRot;

            direction = Vector3.back;
        }


        if (inputReader.inputControls.Player.Left.WasPerformedThisFrame())
        {
            Quaternion newRot = Quaternion.Euler(0, -90, 0);

            playerBody.rotation = newRot;


            direction = Vector3.left;
        }


        if (inputReader.inputControls.Player.Right.WasPerformedThisFrame())
        {
            Quaternion newRot = Quaternion.Euler(0, 90, 0);

            playerBody.rotation = newRot;


            direction = Vector3.right;
        }

        if(inputReader.inputControls.Player.Move.WasPerformedThisFrame() && !isMoving)
        {
            Movement();
        }
    }

    void Movement()
    {
        if (canMove)
        {
            startPos = playerBody.position;
            endPos = direction + startPos;

            transform.position = Vector3.MoveTowards(transform.position, endPos, moveTime);
        }
    }
}
