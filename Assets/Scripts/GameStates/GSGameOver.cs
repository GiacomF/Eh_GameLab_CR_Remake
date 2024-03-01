using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GSGameOver : IGameState
{
    public void OnStateEnter()
    {
        if (LevelManager.instance.currLevel.getScore() > LevelManager.instance.getHighestScore()) 
        {
            LevelManager.instance.setHighestScore(LevelManager.instance.currLevel.getScore());
        }
        UIManager.instance.ShowUI(new List<GameUI>() { GameUI.GameOver, GameUI.Playing });
    }
    public void OnStateExit()
    {
        Time.timeScale = 1;
    }
    public void OnStateUpdate()
    {
    }
    public static void GoToMainMenu()
    {
        GameStateManager.instance.SetCurrentGameState(GameStates.MainMenu);
    }
}
