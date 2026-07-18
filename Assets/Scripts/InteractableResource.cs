using UnityEngine;

public class InteractableResource : MonoBehaviour
{
    public ItemData item;
    public int minPossibleAmount = 2;
    public int maxPossibleAmount = 3;
    public int usesRemaining = 1;

    public string promptText = "Press E to interact";
    public string animationTrigger = "PickFruit";

    public bool destroyWhenEmpty = true;

    public void Interact(Inventory inventory)
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
