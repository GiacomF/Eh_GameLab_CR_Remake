using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Cart : MonoBehaviour
{
    public float Speed;
    void Update()
    {
        transform.Translate(0,0,Speed);
    }
}
