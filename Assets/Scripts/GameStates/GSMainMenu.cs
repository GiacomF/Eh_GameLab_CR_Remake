using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSMainMenu : IGameState
{
    public void OnStateEnter()
    {
        GameStateManager.instance.gameIsPaused = true;
        LevelManager.instance.startLevel();
        UIManager.instance.ShowUI(new List<GameUI>() { GameUI.MainMenu });
    }
    public void OnStateExit()
    {
        
    }
    public void OnStateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) 
        {
            startNewGame();
        }
        else if(Input.GetKeyDown(KeyCode.L))
        {
            Application.Quit();
        }
    }
    public static void Quit()
    {
        GameStateManager.instance.SetCurrentGameState(GameStates.ShuttingOff);
    }

    private void startNewGame()
    {
        GameStateManager.instance.SetCurrentGameState(GameStates.Playing);
    }
}