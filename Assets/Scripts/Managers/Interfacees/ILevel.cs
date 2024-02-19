using UnityEngine;

public interface ILevel
{
    public void init();
    public int getScore();
    public int getCollectedCoins();
    public GameObject getObject();
    public void destroyAllElements();
}