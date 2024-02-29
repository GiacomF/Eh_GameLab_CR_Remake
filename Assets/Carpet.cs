using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carpet : MonoBehaviour
{
    public float Speed;
    void Update()
    {
        transform.Translate(0,0,Speed*Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.SetParent(gameObject.transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        { 
            other.transform.SetParent(LevelManager.instance.currLevel.getObject().transform);
        }
    }
}
