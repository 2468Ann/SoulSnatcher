using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timeLimit = 20f;
    private float timeRemaining;

    public int lives = 2;
    public int score = 0;

    public string correctWord = "SCAN"; // Default for Level 1

    public TMP_Text timerText;
    public TMP_Text livesText;
    public TMP_Text scoreText;
    public TMP_Text statusText;

    private string selectedWord = "";

    void Start()
    {
        timeRemaining = timeLimit;
        UpdateUI();
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.CeilToInt(timeRemaining).ToString();

        if (timeRemaining <= 0)
        {
            statusText.text = "Time's up!";
            Invoke("RestartLevel", 2f);
        }
    }

    public void AddLetter(string letter)
    {
        selectedWord += letter.ToUpper();

        if (selectedWord.Length == correctWord.Length)
        {
            if (selectedWord == correctWord)
            {
                score += 5;
                ScoreManager.Instance.totalScore = score;
                statusText.text = "Correct!";
                UpdateUI();

                // Wait 2 seconds, then load level 2
                Invoke("LoadNextLevel", 2f);
            }
            else
            {
                lives -= 1;
                statusText.text = "Wrong!";
                selectedWord = "";

                if (lives <= 0)
                {
                    statusText.text = "Game Over!";
                    Invoke("RestartLevel", 2f);
                }

                UpdateUI();
            }
        }
    }


    void UpdateUI()
    {
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + ScoreManager.Instance.totalScore;

    }

    void LoadNextLevel()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "level1")
        {
            SceneManager.LoadScene("level2");
        }
        else if (currentScene == "level2")
        {
            SceneManager.LoadScene("level3");
        }
        else if (currentScene == "level3")
        {
            SceneManager.LoadScene("GameOver");
        }
    }


    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}


