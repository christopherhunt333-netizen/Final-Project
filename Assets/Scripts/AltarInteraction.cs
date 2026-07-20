using UnityEngine;

public class AltarInteraction : InteractableObject
{
    public GameManager gameManager;

    public override void Interact(Inventory inventory)
    {
        AltarInteract(inventory);
    }

    private void AltarInteract(Inventory inventory)
    {
        gameManager.GameOver();
    }
}
