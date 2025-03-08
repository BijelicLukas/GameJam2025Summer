using System;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public enum ButtonState { Sound, Terminate}

    public ButtonState currentState;

    private void Start()
    {
        SetButtonState(ButtonState.Sound);
    }

    public event Action<ButtonState> OnButtonStateChange;
    public static event Action<RoomManager.RoomState> TerminatingRoom;

    public void ActivateTermination(RoomManager.RoomState state)
    {
        TerminatingRoom?.Invoke(state);
    }

    public void SetButtonState(ButtonState state)
    {
        currentState = state;
        OnButtonStateChange?.Invoke(state);
    }
}
