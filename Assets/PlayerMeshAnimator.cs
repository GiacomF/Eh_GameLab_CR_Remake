using System.Collections;
using System.Collections.Generic;
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
            playerAnimation.SetTrigger("Hopping");
        }
    }
}
