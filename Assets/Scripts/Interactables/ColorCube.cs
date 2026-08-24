using UnityEngine;
using UnityEngine.InputSystem;

public class ColorCube : Interactable
{
    MeshRenderer mesh;
    private InputManager inputManager;
    public Color[] colors;
    private int colorIndex;

    void Start()
    {
        inputManager = FindAnyObjectByType<InputManager>();
        mesh = GetComponent<MeshRenderer>();
        mesh.material.color = Color.blue;
        promptMessage += " [" + inputManager.onFoot.Interact.GetBindingDisplayString(0) + "]";
    }

    protected override void Interact()
    {
        colorIndex++;
        if (colorIndex > colors.Length - 1)
        {
            colorIndex = 0;
        }
        mesh.material.color = colors[colorIndex];
    }
}
