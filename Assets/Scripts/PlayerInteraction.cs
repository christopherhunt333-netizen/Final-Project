using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRange = 3;
    public TextMeshProUGUI promptText;

    public GameObject torch;
    public Inventory inventory;
    private InteractableObject currentObject;
    private Animator animator;
    private bool isInteracting;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        if (promptText != null)
        {
            promptText.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        FindNearbyObject();
    }

    private void FindNearbyObject()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, interactionRange);

        InteractableObject closestObject = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider hit in hits)
        {
            InteractableObject interactableObject = hit.GetComponentInParent<InteractableObject>();

            if (interactableObject == null)
            {
                continue;
            }

            float distance = Vector3.Distance(transform.position, interactableObject.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = interactableObject;
            }
        }

        currentObject = closestObject;

        if (promptText == null)
        {
            return;
        }

        if (currentObject != null && !isInteracting)
        {
            promptText.text = currentObject.promptText;
            promptText.gameObject.SetActive(true);
        }
        else
        {
            promptText.gameObject.SetActive(false);
        }
    }

    public void OnInteract(InputValue value)
    {
        if (!value.isPressed)
        {
            return;
        }

        if (currentObject == null || isInteracting)
        {
            return;
        }

        StartCoroutine(InteractRoutine());
    }

    private IEnumerator InteractRoutine()
    {
        isInteracting = true;

        if (promptText != null)
        {
            promptText.gameObject.SetActive(false);
        }

        if (animator != null && !string.IsNullOrEmpty(currentObject.animationTrigger))
        {
            animator.SetTrigger(currentObject.animationTrigger);
        }

        yield return new WaitForSeconds(6.1f);

        if (currentObject != null)
        {
            currentObject.Interact(inventory);
        }

        yield return new WaitForSeconds(0.3f);

        isInteracting = false;
    }

    public void OnToggleTorch(InputValue value)
    {
        if (!value.isPressed)
        {
            return;
        }

        if (torch == null)
        {
            return;
        }
        
        bool currentState = torch.activeSelf;
        torch.SetActive(!currentState);

    }
}
