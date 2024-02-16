using UnityEngine;

public interface ILevel
{
    public void Init();
    public int GetScore();
    public int GetLevel();
    public GameObject GetObject();
    public void DestroyAllElements();
}