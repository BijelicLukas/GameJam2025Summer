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
        soundcluesCooldown = 10;
        sounds = GetComponent<OpangasScript>().sounds;
        lowPassFilter = GetComponent<AudioLowPassFilter>();
        lowPassFilter.cutoffFrequency = 500f;
    }

    public void OnEnable()
    {
        lastTime = Time.time;
        room = GetComponent<OpangasScript>().lastAttackedRoom;
        timesOfWarning = 0;
    }

    private void OnDisable()
    {
        lowPassFilter.enabled = false;
    }

    private void Update()
    {
        if(lastTime + soundcluesCooldown < Time.time)
        {
            lowPassFilter.enabled = true;
            randomNumber = Random.Range(0,sounds.Length-1);
            //lowPassFilter = sounds[randomNumber].GetComponent<AudioLowPassFilter>();
            if (timesOfWarning == 0)
            {
                timesOfWarning = 1;
                sounds[randomNumber].pitch = Random.Range(1.25f, 2.5f);
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
