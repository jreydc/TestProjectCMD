using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{

    [SerializeField] private InputActionAsset playerControls;
    
    [SerializeField] private string actionName = "PlayerActionMap";
    
    [SerializeField] private string move = "Move";
    [SerializeField] private string jump = "Jump";

    [SerializeField] private InputAction moveAction; 
    [SerializeField] private InputAction jumpAction; 
    public Vector2 MoveInput { get; private set; }
    public Vector2 JumpInput { get; private set; }

    private void Awake()
    {
        moveAction = playerControls.FindActionMap(actionName).FindAction(move);
        jumpAction = playerControls.FindActionMap(actionName).FindAction(jump);
        RegisterInputActions();
    }

    private void RegisterInputActions()
    {
        moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        moveAction.canceled += context => MoveInput = Vector2.zero;

        jumpAction.performed += context => JumpInput = context.ReadValue<Vector2>();
        jumpAction.canceled += context => JumpInput = Vector2.zero;
    }

    private void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
    }
    
}
