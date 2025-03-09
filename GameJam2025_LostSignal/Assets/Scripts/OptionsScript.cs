using UnityEngine;

[CreateAssetMenu(fileName = "OptionsScript", menuName = "Scriptable Objects/OptionsScript")]
public class OptionsScript : ScriptableObject
{
    //public float Volume;
    public float TimerMinutes;
    public float TimerSeconds;
    public int mistakes;
    public int clickerCounter;
    public int highscore;
}
