using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    public float Speed;

    void Update()
    {
        transform.Translate(0,0,Speed*Time.deltaTime);
    }
}
