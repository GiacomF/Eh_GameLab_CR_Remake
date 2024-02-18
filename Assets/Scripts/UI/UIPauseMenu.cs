using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPauseMenu : MonoBehaviour, IGameUI
{
    public GameUI UiType;

    public Button pauseButton;
    public TextMeshProUGUI countDownText;

    private float unpauseTimer = 3;

    public void Init()
    {
        pauseButton.onClick.AddListener(() => { resumeGame(); });
    }

    public void Update()
    {
        if (unpauseTimer <= 0)
        {
            unpauseTimer = 3;
            GameStateManager.instance.isUnpausingGame = false;

            updateActiveGameObjects(GameStateManager.instance.isUnpausingGame);

            GameStateManager.instance.SetCurrentGameState(GameStates.Playing);
        }
        if (GameStateManager.instance.isUnpausingGame)
        {
            updateActiveGameObjects(GameStateManager.instance.isUnpausingGame);

            int roundedTimer = Mathf.CeilToInt(unpauseTimer);
            countDownText.text = roundedTimer.ToString();
            unpauseTimer -= Time.deltaTime;
        }
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

    private void updateActiveGameObjects(bool isUnpausing) 
    {
        pauseButton.gameObject.SetActive(!isUnpausing);
        countDownText.gameObject.SetActive(isUnpausing);
    }
}
