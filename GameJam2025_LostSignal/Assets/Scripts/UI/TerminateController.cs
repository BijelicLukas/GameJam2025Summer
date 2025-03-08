using UnityEngine;

public class TerminateController : MonoBehaviour
{
    [SerializeField] ButtonManager buttonManager;

    public void OnButtonPressed()
    {
        //Debug.Log($"Current ButtonState: {buttonManager.currentState}");
        if (buttonManager.currentState == ButtonManager.ButtonState.Sound) buttonManager.SetButtonState(ButtonManager.ButtonState.Terminate);
        else buttonManager.SetButtonState(ButtonManager.ButtonState.Sound);
        //Debug.Log($"But now its {buttonManager.currentState} Time!");
    }
}
