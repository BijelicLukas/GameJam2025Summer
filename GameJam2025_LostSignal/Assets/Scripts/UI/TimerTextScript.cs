using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerTextScript : MonoBehaviour
{
    [SerializeField] OptionsScript optionInfo;
    TextMeshProUGUI text;
    float startTimer;
    float TimeDuration;


    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        optionInfo.TimerMinutes = 5;
        optionInfo.TimerSeconds = 50;
        optionInfo.TimerMinutes = 0;
        optionInfo.TimerSeconds = 20;
        startTimer = Time.time;
        TimeDuration = optionInfo.TimerMinutes * 60 + optionInfo.TimerSeconds;
    }

    private void Update()
    {
        if(startTimer + TimeDuration < Time.time)
        {
            SceneManager.LoadScene("Win Screen");
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
