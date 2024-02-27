using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherPitTileCheck : MonoBehaviour
{
    
    Vector3 offset = new Vector3(0,0,1);
    public GameObject[] tiles;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Pillars Tile"))
        {
            Debug.Log("TWin tile detected");
            Destroy(other.gameObject);
            GameObject tile = GameObject.Instantiate(tiles[Random.Range(0,tiles.Length)], gameObject.transform.position + offset, gameObject.transform.rotation, gameObject.transform);
        }
    }
}
