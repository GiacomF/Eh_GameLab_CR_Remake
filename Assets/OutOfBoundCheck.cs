using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundCheck : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy") || other.CompareTag("Carpet"))
        {
            Destroy(other.gameObject);
        }
    }
}
