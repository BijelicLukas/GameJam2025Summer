using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public enum MenuState { MainMenu,Options,Tutorial,Quit}

    [Serializable]
    public class UIElement
    {
        public MenuState state;
        public GameObject canvas;
    }

    public List<UIElement> UIElements;
    public MenuState currentState;
    
    public void SwitchState(MenuState state)
    {
        foreach(UIElement e in UIElements) { e.canvas.SetActive(e.state == state); }
        currentState = state;
    }

    public void Start()
    {
        SwitchState(MenuState.MainMenu);
    }
}
