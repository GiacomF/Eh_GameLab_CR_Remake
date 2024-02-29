using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckExploration : MonoBehaviour
{
    private bool isExploredStripe = false;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !isExploredStripe)
        {
            isExploredStripe = true;
            LevelManager.instance.currLevel.increaseScore(1);
        }
    }
}
