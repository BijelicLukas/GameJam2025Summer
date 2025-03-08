using UnityEngine;

public class OpangasAttack : MonoBehaviour
{
    float lastTime;
    float soundcluesCooldown;
    RoomManager.RoomState room;
    int timesOfWarning;
    AudioSource[] sounds;
    int randomNumber;
    AudioLowPassFilter lowPassFilter;


    private void Start()
    {
        soundcluesCooldown = 5;
        sounds = GetComponent<OpangasScript>().sounds;
        
    }

    public void OnEnable()
    {
        lastTime = Time.time;
        room = GetComponent<OpangasScript>().lastAttackedRoom;
        timesOfWarning = 0;
    }

    private void Update()
    {
        if(lastTime + soundcluesCooldown < Time.time)
        {
            randomNumber = Random.Range(0,sounds.Length-1);
            lowPassFilter = sounds[randomNumber].GetComponent<AudioLowPassFilter>();
            lowPassFilter.cutoffFrequency = 500f;
            if (timesOfWarning == 0)
            {
                timesOfWarning = 1;
                sounds[randomNumber].Play();
                lastTime = Time.time;
                return;
            }
          if(timesOfWarning == 1)
            {
                timesOfWarning = 2;
                sounds[randomNumber ].Play();
                lastTime = Time.time;
                return;
            }
            //Time TO DIE
            GetComponent<OpangasKillScript>().enabled = true;
        }
    }

}
