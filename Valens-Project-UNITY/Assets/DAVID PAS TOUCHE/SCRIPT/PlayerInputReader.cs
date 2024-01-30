using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    public PlayerInputControls inputControls;
    private void OnEnable()
    {
        inputControls.Player.Enable();
    }

    private void OnDisable()
    {
        inputControls.Player.Disable();
    }

    private void Awake()
    {
        inputControls = new PlayerInputControls();
    }
}
