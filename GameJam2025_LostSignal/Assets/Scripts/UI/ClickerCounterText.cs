using TMPro;
using UnityEngine;

public class ClickerCounterText : MonoBehaviour
{
    TextMeshProUGUI text;
    [SerializeField] OptionsScript info;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        info.clickerCounter = 0;
    }

    public void OnButtonClick()
    {
        info.clickerCounter++;
        text.text = info.clickerCounter.ToString();
    }
}
