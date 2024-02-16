using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSPauseMenu : IGameState
{
    public void OnStateEnter()
    {
       UIManager.instance.ShowUI(GameUI.PauseMenu);
    }
    public void OnStateExit()
    {
    }
    public void OnStateUpdate()
    {
    }
}