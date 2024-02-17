using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSPauseMenu : IGameState
{
    private float unpauseTimer = 3;

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
        if (Input.GetKeyUp(KeyCode.Escape) && !GameStateManager.instance.isUnpausingGame)
        {
            GameStateManager.instance.isUnpausingGame = true;
        }
        if (unpauseTimer <= 0)
        {
            unpauseTimer = 3;
            GameStateManager.instance.isUnpausingGame = false;
            GameStateManager.instance.SetCurrentGameState(GameStates.Playing);
        }
        if (GameStateManager.instance.isUnpausingGame)
        {
            Debug.Log(unpauseTimer);
            unpauseTimer -= Time.deltaTime;
        }
    }
}