using UnityEngine;

public class FakersScript : MonoBehaviour
{
    float lastTime;
    float delay;
    int soundIndex;
    [SerializeField] float minDelay, maxDelay;
    [SerializeField] RoomInfosScript RoomInfos;
    public AudioSource[] sounds;
    bool active;
    bool startedSpeaking;

    private void Start()
    {
        soundIndex = 0;
        ButtonManager.TerminatingRoom += AreWeCooked;
        ButtonManager.CallingForRoom += CallBack;
        lastTime = Time.time;
        delay = Random.Range(minDelay, maxDelay);
        active = false;
        startedSpeaking = false;
    }

    private void Update()
    {
        if(!active && lastTime + delay < Time.time) { active = true; }
        if(startedSpeaking && !sounds[soundIndex].isPlaying)
        {
            RoomInfos.RoomRespondsReqeust = false;
            startedSpeaking = false;
        }
    }

    private void AreWeCooked(RoomManager.RoomState state)
    {
        if (!active) return;
        active = false;
        Reset();
    }

    private void CallBack(RoomManager.RoomState state)
    {
        if (!active) return;
        PlaySound();
        RoomInfos.RoomRespondsReqeust = true;
        startedSpeaking = true;
    }

    private void Reset()
    {
        lastTime = Time.time;
        delay = Random.Range(minDelay, maxDelay);
    }

    private void PlaySound()
    {
        soundIndex = Random.Range(0, sounds.Length - 1);
        sounds[soundIndex].Play();
    }
}
