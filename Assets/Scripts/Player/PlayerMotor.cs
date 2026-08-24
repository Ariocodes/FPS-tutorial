using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    public float defaultSpeed = 5f;
    public float sprintSpeed = 8f;
    private float speed;


    bool crouching = false;
    float crouchTimer = 1;
    bool lerpCrouch = false;
    bool sprinting = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        speed = defaultSpeed;
    }


    void Update()
    {
        isGrounded = controller.isGrounded;

        // I have no single idea what's happening here:
        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
                controller.height = Mathf.Lerp(controller.height, 1, p);
            else
                controller.height = Mathf.Lerp(controller.height, 2, p);

            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }
    }

    // receive the inputs for your InputManager.cs and apply them to our character controller.
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if(isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.deltaTime);
        //Debug.Log(playerVelocity.y);
    }


    public void Crouch_Toggle()
    {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }
    public void Crouch_Hold(bool crouching)
    {
        this.crouching = crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }

    public void Sprint_Toggle()
    {
        sprinting = !sprinting;
        if (sprinting)
            speed = sprintSpeed;
        else
            speed = 5;
    }

    public void Sprint_Hold(bool isSprinting)
    {
        speed = isSprinting ? sprintSpeed : 5;
    }



    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
}
