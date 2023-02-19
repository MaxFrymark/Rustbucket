using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] Player player; 
    
    InputActions inputActions;

    private void Start()
    {
        inputActions = new InputActions();

        inputActions.Player.Move.performed += MovePlayer;
        inputActions.Player.Move.canceled += StopPlayer;
        inputActions.Player.Jump.performed += JumpPlayer;

        inputActions.Enable();
    }

    private void MovePlayer(InputAction.CallbackContext context)
    {
        player.Move(context.ReadValue<float>());
    }

    private void StopPlayer(InputAction.CallbackContext context)
    {
        player.StopMove();
    }

    private void JumpPlayer(InputAction.CallbackContext context)
    {
        player.Jump();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
}
