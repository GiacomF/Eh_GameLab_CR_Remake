using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSGameOver : IGameState
{
    public void OnStateEnter()
    {
        UIManager.instance.ShowUI(GameUI.GameOver);
    }
    public void OnStateExit()
    {
    }
    public void OnStateUpdate()
    {
    }
    public static void GoToMainMenu()
    {
        GameStateManager.instance.SetCurrentGameState(GameStates.MainMenu);
    }
}
