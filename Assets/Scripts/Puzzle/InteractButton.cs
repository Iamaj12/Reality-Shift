using UnityEngine;
using UnityEngine.Events;

public class InteractButton : MonoBehaviour, IInteractable
{
    public UnityEvent onPressed;

    private bool hasBeenPressed = false;

    public void Interact()
    {
        if (hasBeenPressed)
            return;

        hasBeenPressed = true;

        onPressed.Invoke();

        Debug.Log("Button Pressed!");
    }
}