using TMPro;
using UnityEngine;

public class WinScreenCounter : MonoBehaviour
{
    TextMeshProUGUI text;
    [SerializeField] OptionsScript Info;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        if(Info.clickerCounter > Info.highscore)
        {
            Debug.Log($"Highscore: {Info.highscore}; Counter: {Info.clickerCounter}; Difference: {Info.clickerCounter - Info.highscore}");
            text.text = $"What a performance! \n you reached a new hight: {Info.clickerCounter} Engagement Points™! \n That's {Info.clickerCounter - Info.highscore} more Points than your personal best";
            Info.highscore = Info.clickerCounter;
            return;
        }
        text.text = $"Congratulations HBS-485132! Your efficiency rating has reached: {Info.clickerCounter}. The company appreciates your dedication.";

    }
}
