using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class SpawnAndDir : MonoBehaviour
{
    public GameObject ENemyToSpawn;
    public GameObject Flag;
    public Transform[] spawns;
    int currentSpawn;
    float timer = 0f;
    float maxTimer = 2;
    float Min;
    float Max;
    public bool IsCart = false;
    public bool IsTrain = false;
    public bool IsCarpet = false;
    void Start()
    {
        currentSpawn = Random.Range(0,spawns.Length);
        Spawn();
    }

    void Update()
    {
        if(IsCart)
        {
            Min = 1.5f;
            Max = 4f;
            timer += Time.deltaTime;
            if(timer > maxTimer)
            {
                timer = 0f;
                Spawn();
                maxTimer = Random.Range(Min, Max);
            }
        }

        if(IsTrain)
        {
            Min = 4f;
            Max = 12f;
            timer += Time.deltaTime;
            if(timer >= maxTimer/2)
            {
                Flag.SetActive(true);
            }
            if(timer > maxTimer)
            {
                Flag.SetActive(false);
                timer = 0f;
                Spawn();
                maxTimer = Random.Range(Min, Max);
            }
        }

        if(IsCarpet)
        {
            Min = 1.5f;
            Max = 4f;
            timer += Time.deltaTime;
            if(timer > maxTimer)
            {
                timer = 0f;
                Spawn();
                maxTimer = Random.Range(Min, Max);
            }
        }
    }

    void Spawn()
    {
        GameObject item = GameObject.Instantiate(ENemyToSpawn, spawns[currentSpawn].position, spawns[currentSpawn].rotation);
    }
}
