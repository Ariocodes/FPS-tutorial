using UnityEngine;
using UnityEngine.InputSystem;

public class CollectCube : Interactable
{
    //public GameObject particle;
    private InputManager inputManager;

    void Start()
    {
        inputManager = FindAnyObjectByType<InputManager>();
        promptMessage += " [" + inputManager.onFoot.Interact.GetBindingDisplayString(0) + "]";
    }

    protected override void Interact()
    {
        Destroy(gameObject);
        //Instantiate(particle, transform.position, Quaternion.identity);
    }
}
