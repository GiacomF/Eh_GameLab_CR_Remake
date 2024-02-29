using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfRangeTrigger : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Tile") || other.CompareTag("Pillars Tile"))
        {
            Destroy(other.gameObject);
            LevelGenerator.instance.GenerateLevelTile();
            Debug.Log("Tile impacted");
        }
    }
}
