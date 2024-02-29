using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EagleEnemy : MonoBehaviour
{
    public bool getPlayer = false;
    float speed = 0.1f;
    public Transform player;

    void Update()
    {
        if(getPlayer)
        {
            transform.position = Vector3.Lerp(transform.position, player.position, speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameStateManager.instance.SetCurrentGameState(GameStates.GameOver);
            other.gameObject.SetActive(false);
        }
    }
}
