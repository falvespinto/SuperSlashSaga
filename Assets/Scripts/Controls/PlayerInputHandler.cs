using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{

    private PlayerInput playerInput;

    private Controls controls;

    Vector2 i_movement;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        var movers = FindObjectOfType<Controls>();
        var index = playerInput.playerIndex;
        controls = movers.FirstOrDefault(m => m.GetPlayerIndex() == index);
    }

    public void OnMove(InputValue value)
    {
        //controls.OnMove(value.Get<Vector2>());
        i_movement = value.Get<Vector2>();
    }

}
