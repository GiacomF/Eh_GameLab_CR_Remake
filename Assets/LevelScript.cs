using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public static LevelScript instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<LevelScript>();
            if (_instance == null)
                Debug.LogError("LevelManager not found, can't create singleton object");
            return _instance;
        }
    }
    private static LevelScript _instance;
    public int SpawnedTiles;
    public bool Generate = false;
    public bool lastTileWasPillar = false;
    public int InitialTiles;
    public int SafePercentage;
    public int IncreaseDifficultyThreshold = 15;
    public GameObject[] DangerousTiles;
    public GameObject[] SafeTiles;
    Vector3 offset = new Vector3(0,0,1);
    public Transform lastGeneratedTile;

    void Start()
    {
        for(int i=0; i < InitialTiles+1; i++)
        {
            GenerateLevelTile();
        }
    }
    void Update()
    {
        Debug.Log(lastGeneratedTile);

        if(Generate)
        {
            GenerateLevelTile();
            Generate = false;
            SpawnedTiles ++;
            if(SpawnedTiles > IncreaseDifficultyThreshold)
            {
                SafePercentage -= 3;
                SpawnedTiles = 0;
            }
        }
    }

    public void GenerateLevelTile()
    {
        int randomPercentageGenerated = Random.Range(0,101);

        if(randomPercentageGenerated <= SafePercentage)
        {
            GameObject tile = GameObject.Instantiate(SafeTiles[Random.Range(0,SafeTiles.Length)], lastGeneratedTile.transform.position + offset, gameObject.transform.rotation, gameObject.transform);
            lastGeneratedTile = tile.transform;
        }
        else
        {
            if(lastTileWasPillar)
            {
                GameObject tile = GameObject.Instantiate(DangerousTiles[Random.Range(0,SafeTiles.Length-1)], lastGeneratedTile.transform.position + offset, gameObject.transform.rotation, gameObject.transform);
                lastGeneratedTile = tile.transform;
                lastTileWasPillar = false;
            }
            else
            {
                GameObject tile = GameObject.Instantiate(DangerousTiles[Random.Range(0,DangerousTiles.Length)], lastGeneratedTile.transform.position + offset, gameObject.transform.rotation, gameObject.transform);
                lastGeneratedTile = tile.transform;
                if(lastGeneratedTile.CompareTag("Pillars Tile"))
                {
                    lastTileWasPillar = true;
                }
            }
        }
    }
}
