using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class LetterCell : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI letterText;

    public void OnPointerClick(PointerEventData eventData)
    {
        letterText.color = Color.cyan;
        GameObject.FindObjectOfType<GameManager>().AddLetter(letterText.text);
        Debug.Log("Letter clicked: " + letterText.text);
    }
}