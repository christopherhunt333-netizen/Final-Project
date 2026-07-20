using UnityEngine;

public class ButtonInteraction : InteractableObject
{
    public GameObject goldenTemple;

    public override void Interact(Inventory inventory)
    {
        ButtonInteract(inventory);
    }

    private void ButtonInteract(Inventory inventory)
    {

        if (goldenTemple == null)
        {
            return;
        }

        goldenTemple.SetActive(true);

        gameObject.SetActive(false);
    }
}
