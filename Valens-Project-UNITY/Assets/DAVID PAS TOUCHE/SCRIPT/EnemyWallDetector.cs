using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWallDetector : MonoBehaviour
{
    public LayerMask groundLayer;
    [Header("WallDetector")]
    public float range = 1;
    public bool isFrontWalled, isBackWalled, isLeftWalles, isRightWalled;


    // Update is called once per frame
    void Update()
    {
        CheckWall();
    }
    void CheckWall()
    {
        isFrontWalled = Physics.Raycast(transform.position, Vector3.forward, range, groundLayer);


        isBackWalled = Physics.Raycast(transform.position, Vector3.back, range, groundLayer);


        isLeftWalles = Physics.Raycast(transform.position, Vector3.left, range, groundLayer);


        isRightWalled = Physics.Raycast(transform.position, Vector3.right, range, groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Debug.DrawRay(transform.position, Vector3.forward * range, Color.red);
        Debug.DrawRay(transform.position, Vector3.back * range, Color.red);
        Debug.DrawRay(transform.position, Vector3.left * range, Color.red);
        Debug.DrawRay(transform.position, Vector3.right * range, Color.red);
    }
}
