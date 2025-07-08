using UnityEngine;
using TMPro;

public class WordGridGenerator : MonoBehaviour
{
    public GameObject letterPrefab;
    public Transform gridParent;
    public int gridSize = 5;

    private string[,] gridLetters = new string[5, 5] {
        { "S", "X", "L", "A", "D" },
        { "T", "C", "R", "A", "P" },
        { "Z", "K", "L", "M", "N" },
        { "P", "Q", "B", "W", "E" },
        { "Y", "H", "G", "U", "I" }
    };

    void Start()
    {
        // Safety check to avoid NullReferenceException
        if (letterPrefab == null)
        {
            Debug.LogError("WordGridGenerator: letterPrefab is not assigned in the Inspector!");
            return;
        }

        if (gridParent == null)
        {
            Debug.LogError("WordGridGenerator: gridParent is not assigned in the Inspector!");
            return;
        }

        for (int y = 0; y < gridSize; y++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                GameObject letterObj = Instantiate(letterPrefab, gridParent);

                TextMeshProUGUI tmp = letterObj.GetComponentInChildren<TextMeshProUGUI>();
                if (tmp == null)
                {
                    Debug.LogError("WordGridGenerator: TextMeshProUGUI component not found in the letterPrefab!");
                    continue;
                }

                tmp.text = gridLetters[y, x];
            }
        }
    }
}
