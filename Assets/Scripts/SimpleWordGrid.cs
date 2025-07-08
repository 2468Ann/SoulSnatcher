using UnityEngine;
using TMPro;

public class SimpleWordGrid : MonoBehaviour
{
    public GameObject letterPrefab;
    public Transform gridParent;
    public string[] word = new string[] { "S", "C", "A", "N" };

    void Start()
    {
        foreach (string letter in word)
        {
            GameObject cell = Instantiate(letterPrefab, gridParent);
            cell.GetComponentInChildren<TextMeshProUGUI>().text = letter;
        }
    }
}