using UnityEngine;

public class InteractableResource : InteractableObject
{
    public ItemData item;
    public int minPossibleAmount = 2;
    public int maxPossibleAmount = 3;
    public bool destroyWhenEmpty = true;

    public override void Interact(Inventory inventory)
    {

        ResourceInteract(inventory);
    }

    private void ResourceInteract(Inventory inventory)
    {
        if (usesRemaining <= 0)
        {
            return;
        }

        if (item != null && inventory != null)
        {
            int amountPerCollect = Random.Range(minPossibleAmount, maxPossibleAmount + 1);
            inventory.AddItem(item, amountPerCollect);
        }

        usesRemaining--;

        if (usesRemaining <= 0 && destroyWhenEmpty)
        {
            gameObject.SetActive(false);
        }
    }
}
