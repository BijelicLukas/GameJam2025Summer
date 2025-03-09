using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class FakersScript : MonoBehaviour
{
    float lastTime;
    float delay;
    int soundIndex;
    [SerializeField] float minDelay, maxDelay;
    [SerializeField] RoomInfosScript RoomInfos;
    FakerAttackScript attackScript;
    public AudioSource[] sounds;
    public static bool active;
    bool startedSpeaking;
    List<RoomManager.RoomState> roomsToRemember;

    private void Start()
    {
        attackScript = GetComponent<FakerAttackScript>();
        roomsToRemember = new List<RoomManager.RoomState>();
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
        if(!active && lastTime + delay < Time.time) 
        {
            active = true;
            attackScript.enabled = true;
            foreach(RoomManager.RoomState room in System.Enum.GetValues(typeof(RoomManager.RoomState)))
            {
                if (RoomInfos.GetRoomStatus(room)) roomsToRemember.Add(room);
                else RoomInfos.SetRoomAttack(room, true);
            }
        }
        if(startedSpeaking && !sounds[soundIndex].isPlaying)
        {
            RoomInfos.RoomRespondsReqeust = false;
            startedSpeaking = false;
        }
    }

    private void AreWeCooked(RoomManager.RoomState state)
    {
        if (!active) return;
        foreach(RoomManager.RoomState room in System.Enum.GetValues(typeof(RoomManager.RoomState)))
        {
            if (roomsToRemember.Contains(room)) continue;
            RoomInfos.SetRoomAttack(room, false);
        }
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
        attackScript.enabled = false;
        lastTime = Time.time;
        delay = Random.Range(minDelay, maxDelay);
        Debug.Log("Vor dem clearen:" + roomsToRemember.Count);
        roomsToRemember.Clear();
        Debug.Log("Nach dem clearen:" + roomsToRemember.Count);

    }

    private void PlaySound()
    {
        soundIndex = Random.Range(0, sounds.Length - 1);
        sounds[soundIndex].Play(44100 * 5);
    }
}
