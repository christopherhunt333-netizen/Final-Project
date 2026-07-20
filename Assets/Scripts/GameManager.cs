using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject gameOverPanelFailure;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI gameOverFailedText;
    public TextMeshProUGUI dayText;

    private int dayCount;
    private float score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dayCount = 0;

        if (dayText != null)
        {
            dayText.text = "Day: " + dayCount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dayText != null)
        {
            dayText.text = "Day: " + dayCount.ToString();
        }

        if (Time.timeScale == 0f && Keyboard.current.spaceKey.isPressed)
        {
            RestartGame();
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f;

        CalculateScore();

        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
        gameOverText.gameObject.SetActive(true);
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

    private void CalculateScore()
    {
        InventorySlotData[] slots = GetComponent<Inventory>().slots;

        foreach (InventorySlotData slot in slots)
        {
            if (slot == null)
            {
                continue;
            }

            float multiplier = slot.item.scoreMultiplier;
            int slotAmount = slot.amount;

            score += multiplier * slotAmount;
        }
    }

    public void FailureGameOver()
    {
        Time.timeScale = 0f;
        scoreText.text = "Did Not Complete";
        gameOverFailedText.gameObject.SetActive(true);
        gameOverPanelFailure.SetActive(true);

    }

}
