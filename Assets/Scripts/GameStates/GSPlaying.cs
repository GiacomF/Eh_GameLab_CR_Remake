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
        UIManager.instance.ShowUI(GameUI.NONE);
        GameStateManager.instance.gameIsPaused = true;
    }
    public void OnStateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            GameStateManager.instance.SetCurrentGameState(GameStates.PauseMenu);
        }
    }
    public static void GoToGameOver()
    {
        GameStateManager.instance.SetCurrentGameState(GameStates.GameOver);
    }
}
