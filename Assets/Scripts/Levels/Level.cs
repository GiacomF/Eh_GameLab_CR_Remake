using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour, ILevel
{
    private int currentScore;

    public void destroyAllElements()
    {
       Debug.Log("Ok distruggo robba!");
    }
    public GameObject getObject()
    {
        return gameObject;
    }

    public int getScore()
    {
        return currentScore;
    }
    public void increaseScore(int value)
    {
        currentScore += value;
    }
    public void init()
    {
        currentScore = 0;
    }
}
