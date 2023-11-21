using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInputReader : MonoBehaviour
{
    public PlayerInputControls intputcontrols;

    private void Awake()
    {
        intputcontrols = new PlayerInputControls();
    }

    private void OnEnable()
    {
        intputcontrols.Enemy.Enable();
    }

    private void OnDisable()
    {
        intputcontrols.Enemy.Disable();
    }
}
