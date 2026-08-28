using UnityEngine;
using UnityEngine.InputSystem;

public class EventOnlyInteractable : Interactable
{
    private InputManager inputManager;
    void Start()
    {
        inputManager = FindAnyObjectByType<InputManager>();
        promptMessage += " [" + inputManager.onFoot.Interact.GetBindingDisplayString(0) + "]";
    }
}
