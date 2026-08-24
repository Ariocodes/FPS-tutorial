using UnityEngine;
using UnityEngine.InputSystem;

public class Keypad : Interactable
{
    [SerializeField]
    private InputManager inputManager;
    [SerializeField]
    private GameObject door;
    private bool doorOpen;
    private Animator doorAnimator;

    private void Awake()
    {
        inputManager = FindAnyObjectByType<InputManager>();
        doorAnimator = door.GetComponent<Animator>();
    }

    private void Start()
    {
        promptMessage += " [" + inputManager.onFoot.Interact.GetBindingDisplayString(0) + "]";
        Debug.Log(promptMessage);
    }

    protected override void Interact()
    {
        doorOpen = !doorOpen;
        doorAnimator.SetBool("isOpen", doorOpen);
        Debug.Log("Interacted with " + gameObject.name);
    }
}
