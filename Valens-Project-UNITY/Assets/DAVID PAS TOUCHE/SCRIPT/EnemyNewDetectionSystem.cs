using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class EnemyDetectionSystem : MonoBehaviour
{
    EnemyFieldOfView fieldOfView;
    public float detectionSize, attackSize;

    public Color detectionColor, attackColor;

    public bool isInDetectionRange;
    public LayerMask playerMask;

    public Transform marker;

    public float markerYOffset =2;


    void Start()
    {
        fieldOfView = GetComponent<EnemyFieldOfView>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fieldOfView.isPlayerDetected)
        {
            isInDetectionRange = Physics.CheckBox(transform.position, new Vector3(detectionSize, detectionSize, detectionSize) / 2, Quaternion.identity, playerMask);

            Collider[] hitPlayer = Physics.OverlapBox(transform.position, new Vector3(detectionSize, detectionSize, detectionSize) / 2, Quaternion.identity, playerMask);
            foreach (Collider col in hitPlayer)
            {
                marker.position = col.transform.position + new Vector3(0, markerYOffset, 0);
            }

            if (isInDetectionRange)
            {
                marker.gameObject.SetActive(true);
            }

            else
            {
                marker.gameObject.SetActive(false);
            }
        }

        else
        {
            isInDetectionRange = false;
            marker.gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = detectionColor;
        Gizmos.DrawCube(transform.position, new Vector3(detectionSize, detectionSize, detectionSize));


        Gizmos.color = attackColor;
        Gizmos.DrawCube(transform.position, new Vector3(attackSize, attackSize, attackSize));
    }
}
