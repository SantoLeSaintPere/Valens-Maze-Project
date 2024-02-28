using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelShower : MonoBehaviour
{
    public GameObject levelToShow, levelToHide;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(!levelToShow.activeSelf)
            {
                levelToShow.SetActive(true);
                levelToHide.SetActive(false);
            }
        }
    }
}
