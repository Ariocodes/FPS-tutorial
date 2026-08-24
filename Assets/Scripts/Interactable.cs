using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    // Add or remove an InteractionEvent component to this gameObject.
    public bool useEvents;
    [SerializeField]
    public string promptMessage; // the message displayed to player when object is looked at.

    public virtual string OnLook()
    {
        return promptMessage; 
    }

    public void BaseInteract()
    {
        if (useEvents)
        {
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        }
        Interact();
    }

    protected virtual void Interact()
    {
        // No code. This is a template function.
    }

}
