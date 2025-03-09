using System.Linq;
using UnityEngine;

public class OpangasDebugScript : OpangasScript
{
    protected override void Start()
    {
        RoomInfos.FillDictionary();
        currentlyAttacking = false;
    }

    protected override void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)) foreach (var entry in RoomInfos.AttackedRooms) Debug.Log($"Wir haben {entry.Key} der folgende Antwort hat ob er angegriffen wird: {entry.Value}");
        if (Input.GetKeyDown(KeyCode.O))
        {
            foreach (var key in RoomInfos.AttackedRooms.Keys.ToList()) RoomInfos.AttackedRooms[key] = false;
            currentlyAttacking = true;
        }

            if (Input.GetKeyDown(KeyCode.Keypad7))
            {
                if (RoomInfos.AttackedRooms[RoomManager.RoomState.LT] == true) { currentlyAttacking = false; return; }
                transform.position = RoomInfos.RoomLTPosition;
                RoomInfos.AttackedRooms[RoomManager.RoomState.LT] = true;
                lastAttackedRoom = RoomManager.RoomState.LT;
                PlaySound();
                return;
            }
            if (Input.GetKeyDown(KeyCode.Keypad8))
            {
                if (RoomInfos.AttackedRooms[RoomManager.RoomState.MT] == true) { currentlyAttacking = false; return; }
                transform.position = RoomInfos.RoomMTPosition;
                RoomInfos.AttackedRooms[RoomManager.RoomState.MT] = true;
                lastAttackedRoom = RoomManager.RoomState.MT;
                PlaySound();
                return;
            }
            if (Input.GetKeyDown(KeyCode.Keypad9))
            {
                if (RoomInfos.AttackedRooms[RoomManager.RoomState.RT] == true) { currentlyAttacking = false; return; }
                transform.position = RoomInfos.RoomRTPosition;
                RoomInfos.AttackedRooms[RoomManager.RoomState.RT] = true;
                lastAttackedRoom = RoomManager.RoomState.RT;
                PlaySound();
                return;
            }
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                if (RoomInfos.AttackedRooms[RoomManager.RoomState.LM] == true) { currentlyAttacking = false; return; }
                transform.position = RoomInfos.RoomLMPosition;
                RoomInfos.AttackedRooms[RoomManager.RoomState.LM] = true;
                lastAttackedRoom = RoomManager.RoomState.LM;
                PlaySound();
                return;
            }
            if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                if (RoomInfos.AttackedRooms[RoomManager.RoomState.MM] == true) { currentlyAttacking = false; return; }
                transform.position = RoomInfos.RoomMMPosition;
                RoomInfos.AttackedRooms[RoomManager.RoomState.MM] = true;
                lastAttackedRoom = RoomManager.RoomState.MM;
                PlaySound();
                return;
            }
            if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                if (RoomInfos.AttackedRooms[RoomManager.RoomState.RM] == true) { currentlyAttacking = false; return; }
                transform.position = RoomInfos.RoomRMPosition;
                RoomInfos.AttackedRooms[RoomManager.RoomState.RM] = true;
                lastAttackedRoom = RoomManager.RoomState.RM;
                PlaySound();
                return;
            }
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                if (RoomInfos.AttackedRooms[RoomManager.RoomState.LL] == true) { currentlyAttacking = false; return; }
                transform.position = RoomInfos.RoomLLPosition;
                RoomInfos.AttackedRooms[RoomManager.RoomState.LL] = true;
                lastAttackedRoom = RoomManager.RoomState.LL;
                PlaySound();
                return;
            }
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                if (RoomInfos.AttackedRooms[RoomManager.RoomState.ML] == true) { currentlyAttacking = false; return; }
                transform.position = RoomInfos.RoomMLPosition;
                RoomInfos.AttackedRooms[RoomManager.RoomState.ML] = true;
                lastAttackedRoom = RoomManager.RoomState.ML;
                PlaySound();
                return;
            }
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                if (RoomInfos.AttackedRooms[RoomManager.RoomState.RL] == true) { currentlyAttacking = false; return; }
                transform.position = RoomInfos.RoomRLPosition;
                RoomInfos.AttackedRooms[RoomManager.RoomState.RL] = true;
                lastAttackedRoom = RoomManager.RoomState.RL;
                PlaySound();
                return;
            }
        //}
    }
}
