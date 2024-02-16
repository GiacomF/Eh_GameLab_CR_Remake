using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPauseMenu : MonoBehaviour, IGameUI
{
    public GameUI UiType;

    public void Init()
    {}

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
        if (active) 
        {
            GameStateManager.instance.gameIsPaused = true;
        }
    }

    public GameUI GetUIType()
    {
        return UiType;
    }
}
