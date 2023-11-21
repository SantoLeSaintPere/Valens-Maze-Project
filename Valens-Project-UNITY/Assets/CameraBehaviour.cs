using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    Vector3 originalPos;
    Transform target;
    public float speed = 0.25f;
    public float resetSpeed = 2;
    public static bool follow;
    public bool move;

    public GameObject cam, cam2;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        target = GameObject.FindGameObjectWithTag("Player").transform;

        cam.SetActive(true); 
        cam2.SetActive(false);



    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            if(follow )
            {
                move = false;
                follow = false;
            }

            else
            {
                move=true;
                follow = true;
            }
        }

        if(move)
        {
            Reset();
        }

        else
        {
            Follow();
        }
    }

    private void Follow()
    {
        cam.SetActive(true);
        cam2.SetActive(false);
        Debug.Log("Follow");
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed);

    }

    private void Reset()
    {
        cam.SetActive(false);
        cam2.SetActive(true);
        Debug.Log("Reset");
        transform.position = Vector3.MoveTowards(transform.position, originalPos, resetSpeed);
    }
}
