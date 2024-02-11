using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSGameOver : IGameState
{
    public void OnStateEnter()
    {
        DestroyAllElements();
        /*UIManager.instance.ShowUI(UIManager.GameUI.GameOver);*/
    }
    public void OnStateExit()
    {
    }
    public void OnStateUpdate()
    {
    }
    public static void GoToMainMenu()
    {
        GameStateManager.instance.SetCurrentGameState(GameStates.MainMenu);
    }
    private void DestroyAllElements()
    {

        List<GameObject> resettables = new List<GameObject>();

        for(int i = 0; i < resettables.Count; i++)
        {
            Object.Destroy(resettables[i].gameObject);
        }
    }
}
