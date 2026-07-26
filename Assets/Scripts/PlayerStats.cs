using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    private int health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 5;

        if (healthText != null)
        {
            healthText.text = "Health: " + health.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (health == 0)
        {
            FindFirstObjectByType<GameManager>().FailureGameOver();
        }
    }

    public void TakeDamage(int damage)
    {
        health = (health - damage >= 0) ? health - damage : 0;

        if (healthText != null)
        {
            healthText.text = "Health: " + health.ToString();
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Hazard Collider Hit");
        
        if (collider.CompareTag("Hazard"))
        {
            TakeDamage(1);
        }

    }
}
