using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSMainMenu : IGameState
{
    public void OnStateEnter()
    {
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