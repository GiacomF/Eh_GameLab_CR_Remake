using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSMainMenu : IGameState
{
    public void OnStateEnter()
    {
        GameStateManager.instance.gameIsPaused = true;
        UIManager.instance.ShowUI(GameUI.MainMenu);
    }
    public void OnStateExit()
    {
        
    }
    public void OnStateUpdate()
    {
    }
    public static void Quit()
    {
        GameStateManager.instance.SetCurrentGameState(GameStates.ShuttingOff);
    }
}