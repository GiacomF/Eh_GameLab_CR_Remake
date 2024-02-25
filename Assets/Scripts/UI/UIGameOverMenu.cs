using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOverMenu : MonoBehaviour, IGameUI
{
    public GameUI UiType;

    public Button returnToMenu;
    public Button pauseButton;
    public TextMeshProUGUI highestScore;


    public void Init()
    {
        returnToMenu.onClick.AddListener(() => { GSGameOver.GoToMainMenu(); });
    }

    public void Update()
    {
        highestScore.text = "Top " + LevelManager.instance.highestScore.ToString();
    }

    public void SetActive(bool active)
    {
        if (active) 
        {
            pauseButton.gameObject.SetActive(false);
        }
        gameObject.SetActive(active);
    }

    public GameUI GetUIType()
    {
        return UiType;
    }
}
