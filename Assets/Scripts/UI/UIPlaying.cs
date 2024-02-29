using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPlaying : MonoBehaviour, IGameUI
{
    public GameUI UiType;

    public TextMeshProUGUI score;
    public TextMeshProUGUI collectedCoins;
    public Button pauseButton;

    public void Init() 
    {
        pauseButton.onClick.AddListener(() => { GameStateManager.instance.SetCurrentGameState(GameStates.PauseMenu); });
    }

    public void SetActive(bool active)
    {
        if (active) 
        {
            pauseButton.gameObject.SetActive(true); ;
        }
        gameObject.SetActive(active);
    }

    public GameUI GetUIType()
    {
        return UiType;
    }
}
