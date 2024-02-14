using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class V_PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float JumpForce;
    public Vector3 nextDir;
    public Vector3 CurrPos;
    public LayerMask ground;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CurrPos = transform.position;
    }

    void Update()
    {
        if(Physics.Raycast(transform.position, -Vector3.up, out RaycastHit ground, 0.8f))
        {
            Direction();
        }
    }


    void Direction()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            nextDir.z = Input.GetAxisRaw ("Vertical");
            Jump();
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            nextDir.z = Input.GetAxisRaw ("Vertical");
            Jump();
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            nextDir.x = Input.GetAxisRaw ("Horizontal");
            Jump();
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            nextDir.x = Input.GetAxisRaw ("Horizontal");
            Jump();
        }

        float movementSpeed = 5f * Time.deltaTime;
        
        if(transform.position != new Vector3 (CurrPos.x, transform.position.y, CurrPos.z) + nextDir)
        {
            transform.position = Vector3.MoveTowards(transform.position,new Vector3 (CurrPos.x, transform.position.y, CurrPos.z) + nextDir, movementSpeed);
        }
        else
        {
            nextDir = Vector3.zero;
            CurrPos = transform.position;
        }
    }

    void Jump()
    {
        Vector3 ForceJump = new Vector3 (0, JumpForce, 0);
        rb.AddForce(ForceJump, ForceMode.Impulse);
    }
}
