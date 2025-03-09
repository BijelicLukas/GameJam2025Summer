using UnityEngine;
using TMPro;

public class ResetTextUpdate : MonoBehaviour
{
    TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void OnDisable()
    {
        text.text = "";
    }

    public void TextReset()
    {
        text.text = "Personal Highscore has been deleted!";
    }
}
