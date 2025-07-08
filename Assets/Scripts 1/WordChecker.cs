using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordChecker : MonoBehaviour
{
    public string targetWord = "SCAN";
    private string currentWord = "";

    public TextMeshProUGUI feedbackText;

    public void AddLetter(string letter)
    {
        currentWord += letter;
        Debug.Log("Current word: " + currentWord);

        if (currentWord.Length == targetWord.Length)
        {
            if (currentWord == targetWord)
            {
                feedbackText.text = "Correct!";
                feedbackText.color = Color.green;
            }
            else
            {
                feedbackText.text = "Wrong!";
                feedbackText.color = Color.red;
            }

            currentWord = "";
        }
    }
}