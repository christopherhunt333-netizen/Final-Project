using UnityEngine;
using TMPro;


public class ResourceCounter : MonoBehaviour
{
    public TextMeshProUGUI appleText;
    public TextMeshProUGUI pearText;
    public TextMeshProUGUI oreText;

    GameManager gameManager;

    private int apples;
    private int pears;
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
        pearText.text = "Pears: " + pears + " / " + gameManager.requiredPears;
        oreText.text = "Ores: " + ores + " / " + gameManager.requiredOres;
    }

    public void AddResource(string resourceName, int amount)
    {
        if (resourceName == "Apple")
        {
            apples += amount;
        }
        else if (resourceName == "Pear")
        {
            pears += amount;
        }
        else if (resourceName == "Ore")
        {
            ores += amount;
        }


        UpdateUI();
    }

    public bool ConditionCheck()
    {
        bool isConditionMet = (apples >= gameManager.requiredApples) && (pears >= gameManager.requiredPears) && (ores >= gameManager.requiredOres);

        return isConditionMet;
    }

    public int GetResourceCount(string resource)
    {
        if (resource == "Apple")
        {
            return apples;
        }
        if (resource == "Pear")
        {
            return pears;
        }
        if (resource == "Ore")
        {
            return ores;
        }

        return 0;
    }

    
}
