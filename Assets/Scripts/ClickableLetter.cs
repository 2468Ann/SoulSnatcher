using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ClickableLetter : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI letterText;
    public WordChecker wordChecker;

    public void OnPointerClick(PointerEventData eventData)
    {
        letterText.color = Color.cyan;
        wordChecker.AddLetter(letterText.text);
    }
}