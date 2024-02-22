using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor.Callbacks;
using UnityEngine;

public class V2_PlayerMovement : MonoBehaviour
{
    public int positionChange = 2;
    Vector3 newPosition;
    public float Speed = 1f;
    public float jumpVariable = 1f;
    public bool startMovement = false;
    public bool CanJump = true;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovementStartAndDirection();

        //if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out ground))

        if(startMovement == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPosition, Speed*Time.deltaTime);
            if(transform.position == newPosition)
            {
                Debug.Log("I'm equal");
                startMovement = false;
            }    
        }
    }

    void MovementStartAndDirection()
    {
        if(CanJump == true)
        {
            if(Input.GetKeyUp(KeyCode.W))
            {
                Jump();
                startMovement = true;
                newPosition = transform.position + new Vector3(0,0,positionChange);
            }
            else if(Input.GetKeyUp(KeyCode.S))
            {
                Jump();
                startMovement = true;
                newPosition = transform.position + new Vector3(0,0,-positionChange);
            }
            else if(Input.GetKeyUp(KeyCode.D))
            {
                Jump();
                startMovement = true;
                newPosition = transform.position + new Vector3(positionChange,0,0);
            }
            else if(Input.GetKeyUp(KeyCode.A))
            {
                Jump();
                startMovement = true;
                newPosition = transform.position + new Vector3(-positionChange,0,0);
            }
        }
    }

    void Jump()
    {
        Vector3 jumpForce = new Vector3 (0, jumpVariable, 0);
        rb.AddForce(jumpForce, ForceMode.Impulse);
    }
}