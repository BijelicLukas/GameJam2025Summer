using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] int ButtonID;
    public RoomManager roomManager;
    [SerializeField] RoomInfosScript RoomInfo;
    [SerializeField] ButtonManager buttonManager;
    bool terminateMode;
    Button myButton;


    private void Start()
    {
        buttonManager.OnButtonStateChange += ChangeMode;
        RoomInfo.RoomRespondsReqeust = false;
        terminateMode = false;
        myButton = GetComponent<Button>();
        ChangeMode(ButtonManager.ButtonState.Sound);
    }

    void ChangeMode(ButtonManager.ButtonState newState)
    {
        if(newState == ButtonManager.ButtonState.Terminate)
        {
            //Debug.Log("IT'S KILLING TIME!");
            terminateMode =true;
            ChangeButtonColor(new Color32(255, 102, 102,255), Color.red, new Color32(145, 0, 0,255));
            
        }
        else
        {
            //Debug.Log("Let's think it through!");
            terminateMode = false;
            ChangeButtonColor(Color.grey, Color.green, new Color32(21, 115, 0,255));
        }
    }

    private void ChangeButtonColor(Color normal, Color highlighted, Color pressed)
    {
        ColorBlock colorBlock = myButton.colors;
        colorBlock.normalColor = normal;
        colorBlock.highlightedColor = highlighted;
        colorBlock.pressedColor = pressed;
        colorBlock.selectedColor = pressed;
        myButton.colors = colorBlock;
    }

    public void OnButtonPressed()
    {
        if (RoomInfo.RoomRespondsReqeust) return;
        RoomInfo.RoomRespondsReqeust = true;
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
