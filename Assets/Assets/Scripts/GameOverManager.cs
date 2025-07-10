using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public TMP_Text finalScoreText;

    void Start()
    {
        if (ScoreManager.Instance != null)
        {
            finalScoreText.text = "Final Score: " + ScoreManager.Instance.totalScore;
        }
        else
        {
            finalScoreText.text = "Final Score: 15";
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
