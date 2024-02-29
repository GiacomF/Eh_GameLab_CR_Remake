using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSPauseMenu : IGameState
{
    public void OnStateEnter()
    {
        Time.timeScale = 0;
        GameStateManager.instance.gameIsPaused = true;
        UIManager.instance.ShowUI(new List<GameUI>() { GameUI.PauseMenu });
    }
    public void OnStateExit()
    {
        Time.timeScale = 1;
        UIManager.instance.ShowUI(new List<GameUI>() { GameUI.NONE });
    }
    public void OnStateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            GameStateManager.instance.isUnpausingGame = true;
        }
    }

    public static void setPlayingState()
    {
        GameStateManager.instance.SetCurrentGameState(GameStates.Playing);
    }
}