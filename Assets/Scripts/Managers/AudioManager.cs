using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance
    {
        get
        {
            if(_instance == null)
                _instance = FindObjectOfType<AudioManager>();
            if(_instance == null)
                Debug.LogError("GameStateManager not found, can't create singleton object");
            return _instance;
        }
    }

    private static AudioManager _instance;
}
