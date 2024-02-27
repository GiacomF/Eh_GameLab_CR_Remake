using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<LevelManager>();
            if (_instance == null)
                Debug.LogError("LevelManager not found, can't create singleton object");
            return _instance;
        }
    }

    public GameObject level;
    public ILevel currLevel;

    private static LevelManager _instance;

    public void startLevel()
    {
        if (currLevel != null)
        {
            GameObject.Destroy(currLevel.getObject());
        }
        currLevel = GameObject.Instantiate(level, Vector3.zero, Quaternion.identity).GetComponent<ILevel>();
    }
}
