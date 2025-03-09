using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource EnemySong;
    public RoomInfosScript soundState;

    private void OnEnable()
    {
        EnemySong.volume = 0f;
    }
    private void Update()
    {
        EnemySong.volume = soundState.volume;
    }
}
