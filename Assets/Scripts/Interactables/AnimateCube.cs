using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateCube : Interactable
{
    InputManager inputManager;
    Animator animator;

    private string startPrompt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputManager = FindAnyObjectByType<InputManager>();
        animator = GetComponent<Animator>();
        startPrompt = promptMessage + " [" + inputManager.onFoot.Interact.GetBindingDisplayString(0) + "]";
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Default"))
        {
            promptMessage = startPrompt;
        }
        else
        {
            promptMessage = "Animating...";
        }
    }
    protected override void Interact()
    {
        animator.Play("Spin");
    }
}
