using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomInfosScript", menuName = "Scriptable Objects/RoomInfos")]
public class RoomInfosScript : ScriptableObject
{
    public Vector3 RoomLTPosition;
    public Vector3 RoomMTPosition;
    public Vector3 RoomRTPosition;
    public Vector3 RoomLMPosition;
    public Vector3 RoomMMPosition;
    public Vector3 RoomRMPosition;
    public Vector3 RoomLLPosition;
    public Vector3 RoomMLPosition;
    public Vector3 RoomRLPosition;

    public event Action<bool> OnRoomRespondsChanged;
    bool roomRespondsRequest = false;
    public bool RoomRespondsReqeust
    {
        get { return roomRespondsRequest; }
        set
        {
            if(roomRespondsRequest != value)
            {
                roomRespondsRequest = value;
                OnRoomRespondsChanged?.Invoke(value);
            }
        }
    }
    

    public Dictionary<RoomManager.RoomState,bool> AttackedRooms = new Dictionary<RoomManager.RoomState, bool>();
    
    public void FillDictionary()
    {
        foreach(RoomManager.RoomState room in System.Enum.GetValues(typeof(RoomManager.RoomState)))
        {
            AttackedRooms[room] = false;
        }
    }

    public void SetRoomAttack(RoomManager.RoomState roomName, bool isUnderAttack)
    {
        AttackedRooms[roomName] = isUnderAttack;
    }

    public bool GetRoomStatus(RoomManager.RoomState roomName)
    {
        return AttackedRooms[roomName];
    }



}
