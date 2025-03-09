using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ButtonSoundMode : MonoBehaviour
{
    [SerializeField] RoomInfosScript RoomInfo;
    [SerializeField] ButtonManager buttonManager;
    [SerializeField] int ButtonID;
    public RoomManager roomManager;
    public void OnButtonPressed()
    {
        if(!enabled) return;
        if (RoomInfo.RoomRespondsReqeust)
        {
            GetComponent<UnityEngine.UI.Button>().interactable = false;
            return;
        }
        
        RoomInfo.RoomRespondsReqeust = true;
        GetComponent<AudioSource>().PlayDelayed(0.25f);
        switch (ButtonID)
        {
            
            case 1:
                CallingRoom(RoomManager.RoomState.LT);
                break;
            case 2:
                CallingRoom(RoomManager.RoomState.MT);
                break;
            case 3:
                CallingRoom(RoomManager.RoomState.RT);
                break;

            case 4:
                CallingRoom(RoomManager.RoomState.LM);
                break;
            case 5:
                CallingRoom(RoomManager.RoomState.MM);
                break;
            case 6:
                CallingRoom(RoomManager.RoomState.RM);
                break;

            case 7:
                CallingRoom(RoomManager.RoomState.LL);
                break;
            case 8:
                CallingRoom(RoomManager.RoomState.ML);
                break;
            case 9:
                CallingRoom(RoomManager.RoomState.RL);
                break;

            default:
                CallingRoom(RoomManager.RoomState.None);
                Debug.Log("Hey Shitface, you forgot to write the Number for the Button. FUCK YOU!");
                break;
        }
    }

    private void CallingRoom(RoomManager.RoomState state)
    {
        buttonManager.ActivateSound(state);
        roomManager.SetRoomState(state);
    }
}
