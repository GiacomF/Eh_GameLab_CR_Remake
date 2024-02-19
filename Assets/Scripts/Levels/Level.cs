using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour, ILevel
{

    private int collectedCoins;
    private int currentScore;

    public void destroyAllElements()
    {
       Debug.Log("Ok distruggo robba!");
    }

    public int getCollectedCoins()
    {
        return collectedCoins;
    }

    public GameObject getObject()
    {
        return gameObject;
    }

    public int getScore()
    {
        return currentScore;
    }
    public void init()
    {
        currentScore = 0;
        collectedCoins = 0;
    }
}
