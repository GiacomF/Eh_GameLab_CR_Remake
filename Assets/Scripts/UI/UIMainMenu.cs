using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour, IGameUI
{
    public GameUI UiType;

    public Button newGameButton;

    public void Init()
    {
        newGameButton.onClick.AddListener(() => { startNewGame(); });
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public GameUI GetUIType()
    {
        return UiType;
    }

    private void startNewGame() 
    {
        //LevelManager.instance.StartLevel();
        GameStateManager.instance.SetCurrentGameState(GameStates.Playing);
    }
}
