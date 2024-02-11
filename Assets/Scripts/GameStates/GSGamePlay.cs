using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSPlaying : IGameState
{
    public void OnStateEnter()
    {
        /*UIManager.instance.ShowUI(UIManager.GameUI.GamePlay);*/
        GameStateManager.instance.gameIsPaused = false;
    }
    public void OnStateExit()
    {
        GameStateManager.instance.gameIsPaused = true;
    }
    public void OnStateUpdate()
    {
    }
    public static void GoToGameOver()
    {
        GameStateManager.instance.SetCurrentGameState(GameStates.GameOver);
    }
}
