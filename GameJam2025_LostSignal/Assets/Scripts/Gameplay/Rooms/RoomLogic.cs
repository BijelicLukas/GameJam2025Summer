using System;
using UnityEngine;
using UnityEngine.UI;

public class RoomLogic : MonoBehaviour
{
    [Header("Raum Manager Sachen")]
    [Space(10)]
    [SerializeField] Button CorrospondingButton;
    AudioSource telephoneAudio;
    AudioLowPassFilter lowPassFilter;
    [SerializeField] RoomManager.RoomState RoomState;
    public RoomManager roomManager;
    [SerializeField] RoomInfosScript RoomInfo;

    
    float lastTime;
    float delay;
    bool allowedToSpeak;
    bool startedSpeaking;

    //public event Action<bool> DoneSpeaking;

    private void Start()
    {
        roomManager.OnRoomStateChanged += OnRoomChange;
        lastTime = Time.time;
        allowedToSpeak = false;
        startedSpeaking = false;

        telephoneAudio = CorrospondingButton.GetComponent<AudioSource>();
        lowPassFilter = telephoneAudio.GetComponent<AudioLowPassFilter>();
        lowPassFilter.cutoffFrequency = 750f;
        
    }

    private void Update()
    {
        //Debug.Log(thisRoom);
        if(allowedToSpeak && lastTime + delay < Time.time)
        {
            lowPassFilter.enabled = true;
            startedSpeaking = true;
            allowedToSpeak = false;
            telephoneAudio.Play();
        }

        if(startedSpeaking && !telephoneAudio.isPlaying)
        {
            lowPassFilter.enabled = false;
            RoomInfo.RoomRespondsReqeust = false;
            startedSpeaking = false;
        }
        
    }
    void OnRoomChange(RoomManager.RoomState newState)
    {
        //Debug.Log($"{thisRoom} is being attack? {RoomInfo.AttackedRooms[thisRoom]}");
        if (newState == RoomState)
        {
            lastTime = Time.time;
            allowedToSpeak = true;
            delay = UnityEngine.Random.Range(3f, 7f);

            if (RoomInfo.AttackedRooms[RoomState])
            {
                allowedToSpeak = false;
                RoomInfo.RoomRespondsReqeust = false;
            }
        }
        
    }

}
