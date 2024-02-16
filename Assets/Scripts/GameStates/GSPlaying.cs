using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSPlaying : IGameState
{
    public void OnStateEnter()
    {
        UIManager.instance.ShowUI(GameUI.Playing);
        GameStateManager.instance.gameIsPaused = false;
    }
    public void OnStateExit()
    {
        GameStateManager.instance.gameIsPaused = true;
    }
    public void OnStateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!GameStateManager.instance.gameIsPaused)
            {
                UIManager.instance.ShowUI(GameUI.PauseMenu);
            }
            else
            {
                GameStateManager.instance.gameIsPaused = false;
                UIManager.instance.ShowUI(GameUI.Playing);
            }
        }
    }
    public static void GoToGameOver()
    {
        GameStateManager.instance.SetCurrentGameState(GameStates.GameOver);
    }
}
