using UnityEngine;

public interface ILevel
{
    public void init();
    public int getScore();
    public void setScore(int newScore);
    public GameObject getObject();
    public void destroyAllElements();
}