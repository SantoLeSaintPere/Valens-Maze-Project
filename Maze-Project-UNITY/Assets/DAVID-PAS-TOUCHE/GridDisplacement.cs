using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDisplacement : MonoBehaviour
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
    }

    // Update is called once per frame
    void Update()
    {
        CheckInputs();
    }

    IEnumerator MovePlayer(Vector3 dir)
    {
        isMoving = true;
        float nextMove = 0;
        startPos = transform.position;
        endPos = startPos + dir;

        while (nextMove < moveTime)
        {
            transform.position = Vector3.MoveTowards(startPos, endPos, nextMove / moveTime);
            nextMove += Time.deltaTime;
            yield return null;
        }

        transform.position = endPos;

        isMoving = false;
    }

    void CheckInputs()
    {
        if (inputReader.inputControls.Player.Up.WasPerformedThisFrame() && !isMoving)
        {

            Quaternion rot = playerBody.rotation;
            Quaternion newRot = Quaternion.Euler(0, 0, 0);

            playerBody.rotation = newRot;

            if (canMove)
            {
                StartCoroutine(MovePlayer(Vector3.forward));
            }

            else
            {
                StopAllCoroutines();
            }
        }


        if (inputReader.inputControls.Player.Down.WasPerformedThisFrame() && !isMoving)
        {

            Quaternion rot = playerBody.rotation;
            Quaternion newRot = Quaternion.Euler(0, 180, 0);

            playerBody.rotation = newRot;

            if (canMove)
            {

                StartCoroutine(MovePlayer(Vector3.back));
            }

            else
            {
                StopAllCoroutines();
            }
        }


        if (inputReader.inputControls.Player.Left.WasPerformedThisFrame() && !isMoving)
        {
            Quaternion rot = playerBody.rotation;
            Quaternion newRot = Quaternion.Euler(0, -90, 0);

            playerBody.rotation = newRot;

            if (canMove)
            {

                StartCoroutine(MovePlayer(Vector3.left));
            }


            else
            {
                StopAllCoroutines();
            }
        }


        if (inputReader.inputControls.Player.Right.WasPerformedThisFrame() && !isMoving)
        {
            Quaternion rot = playerBody.rotation;
            Quaternion newRot = Quaternion.Euler(0, 90, 0);

            playerBody.rotation = newRot;

            if (canMove)
            {

                StartCoroutine(MovePlayer(Vector3.right));
            }


            else
            {
                StopAllCoroutines();
            }
        }

    }

}
