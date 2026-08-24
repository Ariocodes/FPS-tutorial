using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;
    private PlayerMotor motor;
    private PlayerLook look;


    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        // some weird ass code here:
        onFoot.Jump.performed += ctx => motor.Jump(); // calls the motor.jump() method when jump is performed.
        // we also have:
        //         .started
        //         .canceled


        onFoot.Crouch.performed += ctx => motor.Crouch_Hold(true);
        onFoot.Crouch.canceled += ctx => motor.Crouch_Hold(false);
        onFoot.Sprint.performed += ctx => motor.Sprint_Hold(true);
        onFoot.Sprint.canceled += ctx => motor.Sprint_Hold(false);

    }

    void FixedUpdate()
    {
        // tell the player motor to move using the value from our movement action.
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>()); // the ProcessMove function in PlayerMotor.cs is called with the given arguments
    }

    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        // I guess just some method to switch between different input modes.
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
