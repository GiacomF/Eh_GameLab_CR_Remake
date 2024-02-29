using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public BoxCollider playerCollider;
    public V3_PlayerController playerController;
    private Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if(playerController.wasHit == true)
        {
            Debug.Log("animation trigger");
            animator.SetBool("wasHit", true);
            playerCollider.size = new Vector3(playerCollider.size.x, 0.2f, playerCollider.size.z);
        }

        if (GameStateManager.instance.gameIsPaused) return;

        if(playerController.jumpStart)
        {
            animator.SetBool("jumpStart", true);
        }
        else if(playerController.isJumping)
        {
            animator.SetBool("jump", true);
        }
        else
        {
            animator.SetBool("jump", false);
            animator.SetBool("jumpStart", false);
        }
        


        if (Input.GetKeyDown(KeyCode.W)) { gameObject.transform.rotation = Quaternion.Euler(0, 0, 0); }
        if (Input.GetKeyDown(KeyCode.S)) { gameObject.transform.rotation = Quaternion.Euler(0, 180, 0); }
        if (Input.GetKeyDown(KeyCode.A)) { gameObject.transform.rotation = Quaternion.Euler(0, -90, 0); }
        if (Input.GetKeyDown(KeyCode.D)) { gameObject.transform.rotation = Quaternion.Euler(0, 90, 0); }
    }
}
