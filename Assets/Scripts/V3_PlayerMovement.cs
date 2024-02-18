using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class V3_PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float Speed = 2f;
    public float JumpForce;
    public Vector3 nextDir;
    public Vector3 CurrPos;
    public bool isMoving = false;
    public bool CanJump = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CurrPos = transform.position;
    }

    void Update()
    {
        Direction();
        if(isMoving == true)
        {    
            if(transform.position != new Vector3 (CurrPos.x, transform.position.y, CurrPos.z) + nextDir)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3 (CurrPos.x, transform.position.y, CurrPos.z) + nextDir, Speed);
            }
        }
    }


    void Direction()
    {
        if(CanJump)
        {
            if(Input.GetKeyUp(KeyCode.W))
            {
                isMoving = true;
                nextDir.z = Input.GetAxisRaw ("Vertical");                
                Jump();
            }
            else if(Input.GetKeyUp(KeyCode.S))
            {
                isMoving = true;
                nextDir.z = Input.GetAxisRaw ("Vertical");
                Jump();
            }
            else if(Input.GetKeyUp(KeyCode.A))
            {
                isMoving = true;
                nextDir.x = Input.GetAxisRaw ("Horizontal");
                Jump();
            }
            else if(Input.GetKeyUp(KeyCode.D))
            {
                isMoving = true;
                nextDir.x = Input.GetAxisRaw ("Horizontal");
                Jump();
            }
        }
    }

    void Jump()
    {
        Vector3 ForceJump = new Vector3 (0, JumpForce, 0);
        rb.AddForce(ForceJump, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        CanJump = true;
    }

    void OnCollisionExit(Collision collision)
    {
        CanJump = false;
    }
}
