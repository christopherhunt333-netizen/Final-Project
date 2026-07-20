using UnityEngine;

public class HazardInteraction : MonoBehaviour
{
    private int damageDealt = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerStats>().TakeDamage(damageDealt);
        }

    }
}
