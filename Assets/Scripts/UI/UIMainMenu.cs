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
        newGameButton.onClick.AddListener(() => { Debug.Log("Start a game"); });
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
