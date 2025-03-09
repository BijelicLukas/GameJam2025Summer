using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] OptionsScript Info;
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

    // Methoden für Die Buttons:
        // Main Menu
            //Start Game
            public void StartGame() => SceneManager.LoadScene("GameScene");
            // Optionen
            public void ShowOption() => SwitchState(MenuState.Options);
            // Leave Game
            public void ShowQuitScreen() => SwitchState(MenuState.Quit);
            // Tutorial
            public void ShowTutorial() => SwitchState(MenuState.Tutorial);
       // Option & Tutorial
            // Go Back
            public void ShowMainMenu() => SwitchState(MenuState.MainMenu);
        // Highscore reseten
        public void ResetHighscore() => Info.highscore = 0;
    // Win und Lose
    public void GetBackToMenu() => SceneManager.LoadScene("Main Menu");
}
