using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(1, 0, 0);
        }
    }
}
