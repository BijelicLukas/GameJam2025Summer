using TMPro;
using UnityEngine;

public class TimerTextScript : MonoBehaviour
{
    [SerializeField] OptionsScript optionInfo;
    TextMeshProUGUI text;
    float startTimer;
    float TimeDuration;


    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        optionInfo.TimerMinutes = 5;
        optionInfo.TimerSeconds = 50;
    }

    private void OnEnable()
    {
        startTimer = Time.time;
        TimeDuration = optionInfo.TimerMinutes * 60 + optionInfo.TimerSeconds;
    }

    private void Update()
    {
        if(startTimer + TimeDuration < Time.time)
        {
            Debug.Log("Spiel vorbei, du hast gewonnen");
            return;
        }

        text.text = $"Time left: \n{(int)optionInfo.TimerMinutes} minutes \n{(int)optionInfo.TimerSeconds} seconds";

        if(optionInfo.TimerSeconds - Time.deltaTime <= 0)
        {
            optionInfo.TimerMinutes--;
            optionInfo.TimerSeconds = 60;
        }
        optionInfo.TimerSeconds -= Time.deltaTime;

    }


}
