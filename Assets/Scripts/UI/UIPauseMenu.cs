using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPauseMenu : MonoBehaviour, IGameUI
{
    public GameUI UiType;

    public Button pauseButton;

    private bool isChangingGS = false;

    public void Init()
    {
        pauseButton.onClick.AddListener(() => { resumeGame(); });
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public GameUI GetUIType()
    {
        return UiType;
    }

    private void resumeGame() 
    {
        GameStateManager.instance.isUnpausingGame = true;
    }
}
