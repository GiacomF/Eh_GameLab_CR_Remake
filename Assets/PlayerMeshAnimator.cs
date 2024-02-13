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
        PrepareJump();
        Jump();
    }

    void Jump()
    {
        if(Input.GetKeyUp(KeyCode.W))
        {
            playerAnimation.SetTrigger("Hopping");
        }
        else if(Input.GetKeyUp(KeyCode.S))
        {
            playerAnimation.SetTrigger("Hopping");
        }
        else if(Input.GetKeyUp(KeyCode.A))
        {
            playerAnimation.SetTrigger("Hopping");
        }
        else if(Input.GetKeyUp(KeyCode.D))
        {
            playerAnimation.SetTrigger("Hopping");
        }
    }

    void PrepareJump()
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
