using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDirectionPoints : MonoBehaviour
{
    public LayerMask enemyLayer;
    
    public Vector3 direction;

    public bool front;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CkechEnemyDirection();
    }

    private void CkechEnemyDirection()
    {
        RaycastHit backRay;
        Debug.DrawRay(transform.position, Vector3.forward * 10,  Color.red);
        front = Physics.Raycast(transform.position, Vector3.forward, out backRay, 10, enemyLayer);

    }
}
