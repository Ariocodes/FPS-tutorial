using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string promptMessage; // the message displayed to player when object is looked at.


    public void BaseInteract()
    {
        Interact();
    }
    protected virtual void Interact()
    {
        // No code. This is a template function.
    }

}
