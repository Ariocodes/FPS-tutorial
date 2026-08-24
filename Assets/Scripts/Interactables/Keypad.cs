using UnityEngine;
using UnityEngine.InputSystem;

public class Keypad : Interactable
{
    private InputManager inputManager;
    [SerializeField]
    private GameObject door;
    private bool doorOpen;
    private Animator doorAnimator;

    [SerializeField]
    private GameObject button;
    private Animator buttonAnimator;

    private void Awake()
    {
        inputManager = FindAnyObjectByType<InputManager>();
        doorAnimator = door.GetComponent<Animator>();
        buttonAnimator = button.GetComponent<Animator>();
    }

    private void Start()
    {
        promptMessage += " [" + inputManager.onFoot.Interact.GetBindingDisplayString(0) + "]";
        Debug.Log(promptMessage);
    }

    protected override void Interact()
    {
        if(buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Default") && !buttonAnimator.IsInTransition(0))
        {
            buttonAnimator.SetTrigger("isPressed");
            doorOpen = !doorOpen;
            doorAnimator.SetBool("isOpen", doorOpen);
            Debug.Log("Interacted with " + gameObject.name);
        }
    }
}
