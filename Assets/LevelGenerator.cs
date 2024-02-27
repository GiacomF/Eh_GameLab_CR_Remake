using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator instance
    {
        get
        {
            if(_instance == null)
                _instance = FindObjectOfType<LevelGenerator>();
            if(_instance == null)
                Debug.LogError("GameStateManager not found, can't create singleton object");
            return _instance;
        }
    }
    private static LevelGenerator _instance;

    public int SpawnedTiles;
    public bool Generate = false;
    public bool lastTileWasPillar = false;
    public int InitialTiles;
    public GameObject[] tiles;
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
        }
    }

    public void GenerateLevelTile()
    {
        if(lastTileWasPillar)
        {
            GameObject tile = GameObject.Instantiate(tiles[Random.Range(0,4)], lastGeneratedTile.transform.position + offset, gameObject.transform.rotation, gameObject.transform);
            lastGeneratedTile = tile.transform;
            lastTileWasPillar = false;
        }
        else
        {
            GameObject tile = GameObject.Instantiate(tiles[Random.Range(0,tiles.Length)], lastGeneratedTile.transform.position + offset, gameObject.transform.rotation, gameObject.transform);
            lastGeneratedTile = tile.transform;
            if(lastGeneratedTile.CompareTag("Pillars Tile"))
            {
                lastTileWasPillar = true;
            }
        }
    }
}
