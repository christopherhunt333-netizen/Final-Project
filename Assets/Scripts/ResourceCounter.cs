using UnityEngine;
using TMPro;


public class ResourceCounter : MonoBehaviour
{
    public TextMeshProUGUI appleText;
    public TextMeshProUGUI oreText;

    GameManager gameManager;

    private int apples;
    private int ores;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        UpdateUI();
    }

    private void UpdateUI()
    {
        appleText.text = "Apples: " + apples + " / " + gameManager.requiredApples;
        oreText.text = "Ores: " + ores + " / " + gameManager.requiredOres;
    }

    public void AddResource(string resourceName, int amount)
    {
        if (resourceName == "Apple")
        {
            apples += amount;
        }
        else if (resourceName == "Ore")
        {
            ores += amount;
        }


        UpdateUI();
    }

    public bool ConditionCheck()
    {
        bool isConditionMet = (apples >= gameManager.requiredApples) && (ores >= gameManager.requiredOres);

        return isConditionMet;
    }

    public int GetResourceCount(string resource)
    {
        if (resource == "Apple")
        {
            return apples;
        }
        if (resource == "Ore")
        {
            return ores;
        }

        return 0;
    }

    
}
