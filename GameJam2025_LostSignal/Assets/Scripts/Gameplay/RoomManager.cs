using System;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
   public enum RoomState
    {
        None,
        LT,
        MT,
        RT,
        LM,
        MM,
        RM,
        LL,
        ML,
        RL
    }

    private RoomState currentState;

    private void Start()
    {
        SetRoomState(RoomState.None);
    }

    public event Action<RoomState> OnRoomStateChanged;
    

    public void SetRoomState(RoomState newState)
    {
        currentState = newState;
        Debug.Log($"We changed our focus to Room {currentState}");
        OnRoomStateChanged?.Invoke(currentState);
    }
}
