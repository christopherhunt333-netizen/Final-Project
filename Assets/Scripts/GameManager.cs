using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreText;

    ResourceCounter resourceCounter;

    public int requiredApples;
    public int requiredOres;

    private int dayCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dayCount = 0;
        resourceCounter = GetComponent<ResourceCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (resourceCounter == null)
        {
            return;
        }

        if (resourceCounter.ConditionCheck())
        {
            GameOver();
        }

        if (Time.timeScale == 0f && Keyboard.current.spaceKey.isPressed)
        {
            RestartGame();
        }
    }

    void GameOver()
    {
        Time.timeScale = 0f;

        int score = CalculateTotalScore();

        scoreText.text = "Score: " + score;
        gameOverPanel.SetActive(true);

    }

    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateDayCount()
    {
        dayCount++;
    }

    private int CalculateTotalScore()
    {
        int score = 0;

        int appleScore = CalculateResourceScore("Apple");
        int oreScore = CalculateResourceScore("Ore");

        score += appleScore;
        score += oreScore;

        score /= dayCount;
        
        return score;
    }

    private int CalculateResourceScore(string resource)
    {
        int resourceScore = 0;

        if (resource == "Apple")
        {
            resourceScore = 2 * (resourceCounter.GetResourceCount(resource) - requiredApples) + requiredApples;
        }
        else if (resource == "Ore")
        {
            resourceScore = 2 * (resourceCounter.GetResourceCount(resource) - requiredOres) + requiredOres;
        }

        return resourceScore;
         
    }

}
