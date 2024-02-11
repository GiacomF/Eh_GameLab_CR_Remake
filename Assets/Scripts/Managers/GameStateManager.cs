using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance
    {
        get
        {
            if(_instance == null)
                _instance = FindAnyObjectByType<GameStateManager>();
            if(_instance == null)
                Debug.LogError("GameStateManager not found, can't create singleton object");
            return _instance;
        }
    }

    public bool gameIsPaused = true;

    private static GameStateManager _instance;
    private Dictionary<GameStates, IGameState> registeredGameStates = new Dictionary<GameStates, IGameState>();
    private IGameState currentGameState = null;

    public void RegisterState(GameStates gameState, IGameState state)
    {
        registeredGameStates.Add(gameState, state);
    }

    public void SetCurrentGameState(GameStates gameState)
    {
        if(currentGameState != null)
        {
            currentGameState.OnStateExit();
        }

        IGameState newstate = registeredGameStates[gameState];
        newstate.OnStateEnter();
        currentGameState = newstate;
    }

    private void Update()
    {
        if(currentGameState != null)
        {
            currentGameState.OnStateUpdate();
        }
    }

    
}
