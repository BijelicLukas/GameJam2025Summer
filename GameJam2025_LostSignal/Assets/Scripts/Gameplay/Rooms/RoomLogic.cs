using UnityEngine;
using UnityEngine.UI;

public class RoomLogic : MonoBehaviour
{
    [Header("Raum Manager Sachen")]
    [Space(10)]
    [SerializeField] Button CorrospondingButton;
    AudioSource telephoneAudio;
    AudioLowPassFilter lowPassFilter;
    [SerializeField] RoomManager.RoomState roomState;
    public RoomManager roomManager;

    float lastTime;
    float Delay;
    bool allowedToSpeak;


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
        if(allowedToSpeak && lastTime + Delay < Time.time)
        {
            lowPassFilter.enabled = true;
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
        if(newState == roomState)
        {
            lastTime = Time.time;
            allowedToSpeak = true;
            Delay = Random.Range(2f, 3.1f);
        }
    }

}
