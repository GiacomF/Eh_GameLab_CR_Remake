using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject Coin;
    public Transform[] pos;
    public float MaxGenerationChance = 90f;
    void Start()
    {
        float ChanceGenerated = Random.Range(0,101);

        if(ChanceGenerated <= MaxGenerationChance)
        {
            GameObject.Instantiate(Coin, pos[Random.Range(0,pos.Length)].position, gameObject.transform.rotation, gameObject.transform);
        }
    }
}
