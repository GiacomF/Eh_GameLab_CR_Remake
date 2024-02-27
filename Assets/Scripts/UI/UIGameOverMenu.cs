using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOverMenu : MonoBehaviour, IGameUI
{
    public GameUI UiType;

    public Button returnToMenu;

    public void Init()
    {
        returnToMenu.onClick.AddListener(() => { GSGameOver.GoToMainMenu(); });
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public GameUI GetUIType()
    {
        return UiType;
    }
}
