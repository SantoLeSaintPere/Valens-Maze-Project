using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFacePlayer : MonoBehaviour
{
    EnemyDetectionSystem enemyDetectionSystem;
    Transform target;

    public Transform body;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        enemyDetectionSystem = GetComponent<EnemyDetectionSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyDetectionSystem.isInDetectionRange)
        {
            Vector3 pos = target.position - transform.position;
            body.rotation = Quaternion.LookRotation(pos, Vector3.up);
        }

        else
        {
            //body.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
