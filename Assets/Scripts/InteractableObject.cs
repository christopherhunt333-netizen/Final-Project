using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string animationTrigger;
    public string promptText;
    public int usesRemaining = 1;
    public virtual void Interact(Inventory inventory)
    {
        Debug.Log("Interact Method on Parent Class was called");
    }
}
