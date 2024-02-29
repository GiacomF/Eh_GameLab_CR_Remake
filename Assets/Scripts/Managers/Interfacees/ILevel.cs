using UnityEngine;

public interface ILevel
{
    public void init();
    public int getScore();
    public void increaseScore(int score);
    public GameObject getObject();
    public void destroyAllElements();
}