using System;
using UnityEngine;

public class ButtonTerminateMode : MonoBehaviour
{
    [SerializeField] RoomInfosScript RoomInfo;
    [SerializeField] ButtonManager buttonManager;
    [SerializeField] int ButtonID;
    [SerializeField] OptionsScript optionInfo;
    public RoomManager roomManager;

    private void Start()
    {
        optionInfo.mistakes = 0;
    }

    public void OnButtonPressed()
    {
        if (!enabled) return;
        Debug.Log($"So many mistakes were made:" + optionInfo.mistakes);
        switch (ButtonID)
        {
            case 1:
                if (RoomInfo.AttackedRooms[RoomManager.RoomState.LT])
                {
                    Debug.Log($"Gotcha");
                    buttonManager.ActivateTermination(RoomManager.RoomState.LT);
                    return;
                }
                optionInfo.mistakes++;
                break;
            case 2:
                if (RoomInfo.AttackedRooms[RoomManager.RoomState.MT])
                {
                    Debug.Log($"Gotcha");
                    buttonManager.ActivateTermination(RoomManager.RoomState.MT);
                    return;
                }
                optionInfo.mistakes++;
                break;
            case 3:
                if (RoomInfo.AttackedRooms[RoomManager.RoomState.RT])
                {
                    Debug.Log($"Gotcha");
                    buttonManager.ActivateTermination(RoomManager.RoomState.RT);
                    return;
                }
                optionInfo.mistakes++;
                break;

            case 4:
                if (RoomInfo.AttackedRooms[RoomManager.RoomState.LM])
                {
                    Debug.Log($"Gotcha");
                    buttonManager.ActivateTermination(RoomManager.RoomState.LM);
                    return;
                }
                optionInfo.mistakes++;
                break;
            case 5:
                if (RoomInfo.AttackedRooms[RoomManager.RoomState.MM])
                {
                    Debug.Log($"Gotcha");
                    buttonManager.ActivateTermination(RoomManager.RoomState.MM);
                    return;
                }
                optionInfo.mistakes++;
                break;
            case 6:
                if (RoomInfo.AttackedRooms[RoomManager.RoomState.RM])
                {
                    Debug.Log($"Gotcha");
                    buttonManager.ActivateTermination(RoomManager.RoomState.RM);
                    return;
                }
                optionInfo.mistakes++;
                break;

            case 7:
                if (RoomInfo.AttackedRooms[RoomManager.RoomState.LL])
                {
                    Debug.Log($"Gotcha");
                    buttonManager.ActivateTermination(RoomManager.RoomState.LL);
                    return;
                }
                optionInfo.mistakes++;
                break;
            case 8:
                if (RoomInfo.AttackedRooms[RoomManager.RoomState.ML])
                {
                    Debug.Log($"Gotcha");
                    buttonManager.ActivateTermination(RoomManager.RoomState.ML);
                    return;
                }
                optionInfo.mistakes++;
                break;
            case 9:
                if (RoomInfo.AttackedRooms[RoomManager.RoomState.RL])
                {
                    Debug.Log($"Gotcha");
                    buttonManager.ActivateTermination(RoomManager.RoomState.RL);
                    return;
                }
                optionInfo.mistakes++;
                break;

            default:
                roomManager.SetRoomState(RoomManager.RoomState.None);
                Debug.Log("Hey Shitface, you forgot to write the Number for the Button. FUCK YOU!");
                break;
        }
    }
}
