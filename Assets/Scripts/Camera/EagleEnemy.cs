using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EagleEnemy : MonoBehaviour
{
    public bool getPlayer = false;
    int currentTarget = 0;
    float speed = 0.1f;
    public Transform[] waypoints;

    void Update()
    {
        if(getPlayer)
        {
            transform.position = Vector3.Lerp(transform.position, waypoints[currentTarget].position, speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Got him!");
            GameObject.DestroyObject(other);
        }
    }
}
