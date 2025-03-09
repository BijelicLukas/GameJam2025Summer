using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ButtonController : MonoBehaviour
{
    
    
    [SerializeField] RoomInfosScript RoomInfo;
    [SerializeField] ButtonManager buttonManager;
    UnityEngine.UI.Button myButton;
    ButtonTerminateMode terminateScript;
    ButtonSoundMode soundScript;

    

    private void Start()
    {
        buttonManager.OnButtonStateChange += ChangeMode;
        RoomInfo.OnRoomRespondsChanged += ToggleButtons;
        RoomInfo.RoomRespondsReqeust = false;
        terminateScript = GetComponent<ButtonTerminateMode>();
        soundScript = GetComponent<ButtonSoundMode>();
        myButton = GetComponent<UnityEngine.UI.Button>();
        ChangeMode(ButtonManager.ButtonState.Sound);

    }

    private void OnDestroy()
    {
        RoomInfo.OnRoomRespondsChanged -= ToggleButtons;
    }

    void ChangeMode(ButtonManager.ButtonState newState)
    {
        if(newState == ButtonManager.ButtonState.Terminate)
        {
            //Debug.Log("IT'S KILLING TIME!");
            terminateScript.enabled = true;
            soundScript.enabled = false;
            ChangeButtonColor(new Color32(255, 102, 102,255), Color.red, new Color32(145, 0, 0,255));
            
        }
        else
        {
            //Debug.Log("Let's think it through!");
            terminateScript.enabled = false;
            soundScript.enabled = true;
            ChangeButtonColor(Color.grey, Color.green, new Color32(21, 115, 0,255));
        }
    }

    void ToggleButtons(bool isWaiting)
    {
        myButton.interactable = !isWaiting;
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

   
}
