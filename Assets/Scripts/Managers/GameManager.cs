using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance
    {
        get 
        {
            if (_instance == null)
                _instance = FindAnyObjectByType<GameManager>();
            if(_instance == null)
                Debug.LogError("GameManager not found, can't create singleton object");
            return _instance; 
        }
    }

    public GameStates startingState;

    private static GameManager _instance;


    private void Awake()
    {
        /*  
            GameStateManager.instance.RegisterState(GameStateManager.GameStates.MainMenu, new GSMainMenu());
            GameStateManager.instance.RegisterState(GameStateManager.GameStates.GamePlay, new GSGamePlay());
        */  
    }

    private void Start()
    {
        GameStateManager.instance.SetCurrentGameState(startingState);
    }


    public void CloseApplication()
    {
        Application.Quit();
    }
}
