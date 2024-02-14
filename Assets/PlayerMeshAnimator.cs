using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

public class PlayerMeshAnimator : MonoBehaviour
{
    Animator playerAnimation;

    void Start()
    {
        playerAnimation = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            playerAnimation.SetTrigger("Preparing");
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            playerAnimation.SetTrigger("Preparing");
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            playerAnimation.SetTrigger("Preparing");
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            playerAnimation.SetTrigger("Preparing");
        }
    }
}
