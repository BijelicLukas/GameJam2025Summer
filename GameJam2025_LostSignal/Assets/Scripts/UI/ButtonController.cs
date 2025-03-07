using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] int ButtonID;
    public RoomManager roomManager;

    public void OnButtonPressed()
    {
        GetComponent<AudioSource>().PlayDelayed(0.25f);
        switch(ButtonID)
        {
            case 1:
                roomManager.SetRoomState(RoomManager.RoomState.LT);
                break;
            case 2:
                roomManager.SetRoomState(RoomManager.RoomState.MT);
                break;
            case 3:
                roomManager.SetRoomState(RoomManager.RoomState.RT);
                break;

            case 4:
                roomManager.SetRoomState(RoomManager.RoomState.LM);
                break;
            case 5:
                roomManager.SetRoomState(RoomManager.RoomState.MM);
                break;
            case 6:
                roomManager.SetRoomState(RoomManager.RoomState.RM);
                break;

            case 7:
                roomManager.SetRoomState(RoomManager.RoomState.LL);
                break;
            case 8:
                roomManager.SetRoomState(RoomManager.RoomState.ML);
                break;
            case 9:
                roomManager.SetRoomState(RoomManager.RoomState.RL);
                break;

            default:
                roomManager.SetRoomState(RoomManager.RoomState.None);
                Debug.Log("Hey Shitface, you forgot to write the Number for the Button. FUCK YOU!");
                break;
        }
    }
}
