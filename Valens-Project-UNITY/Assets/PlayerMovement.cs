using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerSpawnTraces playerLastPos;
    PlayerInputReader inputReader;

    [Header("PLAYER BODY")]
    public Transform playerBody;


    [Header("PLAYER MOVEMENT")]
    public Vector3 direction,startPos, endPos;
    public float moveTime = 1;

    GroundWallDetector groundWallDetector;
    bool isMoving;

    public float displacement;
    EnemyStateMachine enemyStateMachine;
    void Start()
    {
        inputReader = GetComponent<PlayerInputReader>();
        groundWallDetector = GetComponent<GroundWallDetector>();
        playerLastPos = GetComponent<PlayerSpawnTraces>();
        direction = new Vector3(0, 0, displacement);

        //enemyPatrolSystem = FindObjectOfType<EnemyPatrolSystem>();
        enemyStateMachine = FindObjectOfType<EnemyStateMachine>();
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


            direction = new Vector3(0, 0, displacement);

        }


        if (inputReader.inputControls.Player.Down.WasPerformedThisFrame())
        {
            Quaternion newRot = Quaternion.Euler(0, 180, 0);

            playerBody.rotation = newRot;

            direction = new Vector3(0, 0, -displacement);

        }


        if (inputReader.inputControls.Player.Left.WasPerformedThisFrame())
        {
            Quaternion newRot = Quaternion.Euler(0, -90, 0);

            playerBody.rotation = newRot;


            direction = new Vector3(-displacement, 0, 0);

        }


        if (inputReader.inputControls.Player.Right.WasPerformedThisFrame())
        {
            Quaternion newRot = Quaternion.Euler(0, 90, 0);

            playerBody.rotation = newRot;


            direction = new Vector3(displacement, 0, 0);
        }

        if(inputReader.inputControls.Player.Move.WasPerformedThisFrame())
        {
            if(!isMoving && groundWallDetector.isGrounded && !groundWallDetector.isWalled)
            {
                playerLastPos.SpawnOBj();
                Movement();
            }
        }
    }

    void Movement()
    {
        startPos = transform.position;
        endPos = direction + startPos;

        transform.position = Vector3.MoveTowards(transform.position, endPos, moveTime);
    }
}
