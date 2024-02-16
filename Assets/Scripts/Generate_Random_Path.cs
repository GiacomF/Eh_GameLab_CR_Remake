using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class Generate_Random_Path : MonoBehaviour
{
    public List<GameObject> SafeBlocks;
    public List<GameObject> UnsafeBlocks;
    List<bool> Safe = new List<bool>();
    public float InitialPercentage;
    public int LevelThreshold;
    public int MaxRoad; 

    void Start()
    {
        GenerateList(InitialPercentage, LevelThreshold, MaxRoad);
    }
    public void GenerateList(float InitialPercentage, int LevelThreshold, int MaxRoad)
    {
        for(int i = 0; i < MaxRoad; i++)
        {
            float GeneratePercentage = UnityEngine.Random.value;
            Safe.Add(GeneratePercentage < InitialPercentage - MathF.Truncate(i/LevelThreshold) * 0.05f);
            Vector3 NewBLockPosition = new Vector3(transform.position.x, transform.position.y,transform.position.z + i);
            GameObject RandomObject;

            if(Safe[i])
            {
                RandomObject = SafeBlocks[UnityEngine.Random.Range(0, SafeBlocks.Count)];
            }
            else
            {
                RandomObject = UnsafeBlocks[UnityEngine.Random.Range(0, UnsafeBlocks.Count)];
            }

            GameObject SpawnedObject = GameObject.Instantiate(RandomObject);
            SpawnedObject.transform.position = NewBLockPosition;
        }
    }
}
