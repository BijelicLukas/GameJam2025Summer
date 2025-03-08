using System;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public enum ButtonState { Sound, Terminate}

    public ButtonState currentState;

    private void Start()
    {
        currentState = ButtonState.Sound;
    }

    public event Action<ButtonState> OnButtonStateChange;

    public void SetButtonState(ButtonState state)
    {
        currentState = state;
        OnButtonStateChange?.Invoke(state);
    }
}
