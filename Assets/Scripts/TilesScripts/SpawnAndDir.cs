using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class SpawnAndDir : MonoBehaviour
{
    public GameObject[] ENemyToSpawn;
    public GameObject Flag;
    public Transform[] spawns;
    int currentSpawn;
    float timer = 0f;
    float maxTimer = 2;
    float Min;
    float Max;
    float maxPillars = 5f;
    public bool IsCart = false;
    public bool IsTrain = false;
    public bool IsCarpet = false;
    public bool isPillar = false;
    void Start()
    {
        if(isPillar)
        {   
            for(int i=0; i < maxPillars; i++)
            {
                Debug.Log("I'm spawning");
                Spawn(Random.Range(0,spawns.Length));
            }
        }
        else
        {
            currentSpawn = Random.Range(0,spawns.Length);
            Spawn(currentSpawn);
        }
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
                Spawn(currentSpawn);
                maxTimer = Random.Range(Min, Max);
            }
        }

        if(IsTrain)
        {
            Min = 4f;
            Max = 12f;
            timer += Time.deltaTime;
            if(timer >= maxTimer-2)
            {
                Flag.SetActive(true);
            }
            if(timer > maxTimer)
            {
                Flag.SetActive(false);
                timer = 0f;
                Spawn(currentSpawn);
                maxTimer = Random.Range(Min, Max);
            }
        }

        if(IsCarpet)
        {
            Min = 2f;
            Max = 4.5f;
            timer += Time.deltaTime;
            if(timer > maxTimer)
            {
                timer = 0f;
                Spawn(currentSpawn);
                maxTimer = Random.Range(Min, Max);
            }
        }
    }

    void Spawn(int currentSpawn)
    {
        GameObject item = GameObject.Instantiate(ENemyToSpawn[0], spawns[currentSpawn].position, spawns[currentSpawn].rotation);
        item.transform.SetParent(gameObject.transform);
    }
}
