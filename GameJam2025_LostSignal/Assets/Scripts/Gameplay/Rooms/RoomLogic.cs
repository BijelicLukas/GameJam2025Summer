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

    //public event Action<bool> DoneSpeaking;

    private void Start()
    {
        roomManager.OnRoomStateChanged += OnRoomChange;
        lastTime = Time.time;
        allowedToSpeak = false;

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
            RoomInfo.RoomRespondsReqeust = false;
            Debug.Log("Lets fucking go, SPEAKING");
            allowedToSpeak = false;
            telephoneAudio.Play();
        }

        if(!telephoneAudio.isPlaying)
        {
            lowPassFilter.enabled = false;
        }
        
    }
    void OnRoomChange(RoomManager.RoomState newState)
    {
        //Debug.Log($"{thisRoom} is being attack? {RoomInfo.AttackedRooms[thisRoom]}");
        if (newState == RoomState)
        {
            lastTime = Time.time;
            allowedToSpeak = true;
            delay = UnityEngine.Random.Range(2f, 3f);

            if (RoomInfo.AttackedRooms[RoomState])
            {
                delay = UnityEngine.Random.Range(5f, 7f);
                Debug.Log("You found the Opanga");
            }
        }
        
    }

}
