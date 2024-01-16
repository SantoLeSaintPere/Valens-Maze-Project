using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnTraces : MonoBehaviour
{
    public Vector3 lastPos;

    public GameObject spawnLastPosOBj;
    public float spawnObjYOffset = 0.5f;

    public bool canSpawnOBj  = true;

    public Transform body;
    public void SpawnOBj()
    {
        if(canSpawnOBj)
        {
            lastPos = new Vector3(transform.position.x, spawnObjYOffset, transform.position.z);
            GameObject Point = Instantiate(spawnLastPosOBj, lastPos, body.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Traces"))
        {
            canSpawnOBj = false;
        }

        else
        {
            canSpawnOBj=true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canSpawnOBj = true;
    }
}
