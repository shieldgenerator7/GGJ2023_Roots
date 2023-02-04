using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Transform center;

    private InputState inputState;

    private void Update()
    {
        InputState prevInputState = inputState;
        prevInputState.movementDirection = inputState.movementDirection;
        //Movement
        inputState.movementDirection.x = Input.GetAxis("Horizontal");
        inputState.movementDirection.y = Input.GetAxis("Vertical");
        //Jump
        inputState.jump = Input.GetButton("Jump");
        //Run
        inputState.run = Input.GetButton("Run");
        //Interact
        inputState.interact = Input.GetButton("Interact");
        //Ability1
        inputState.ability1 = false;// Input.GetButton("Ability1");
        //Ability2
        inputState.ability2 = false;// Input.GetButton("Ability2");
        //Look Direction
        Vector2 prevLookDirection = inputState.lookDirection;
        Vector3 mousePos = Input.mousePosition;
        Vector2 lookPosition = Utility.ScreenToWorldPoint(mousePos);
        inputState.lookDirection = (lookPosition - (Vector2)center.position).normalized;
        
        //Check input changed
        checkInputChanged(prevInputState);
    }

    private void checkInputChanged(InputState newInputState)
    {
        if (this.inputState != newInputState)
        {
            onInputStateChanged?.Invoke(inputState);
        }
    }
    public delegate void OnInputStateChanged(InputState inputState);
    public event OnInputStateChanged onInputStateChanged;

}
