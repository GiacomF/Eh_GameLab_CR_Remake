using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSPauseMenu : IGameState
{
    public void OnStateEnter()
    {
        GameStateManager.instance.gameIsPaused = true;
        UIManager.instance.ShowUI(GameUI.PauseMenu);
    }
    public void OnStateExit()
    {
        UIManager.instance.ShowUI(GameUI.NONE);
    }
    public void OnStateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            GameStateManager.instance.isUnpausingGame = true;
        }
    }
}