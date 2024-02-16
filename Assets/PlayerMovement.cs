using System;
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public int MoveDistance;
    public float JumpForce;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
   void Update()
   {
        MeshRotate();

        if(Input.GetKeyUp(KeyCode.W))
        {
            Move(Vector3.forward*MoveDistance);
            Jump();
        }
        else if(Input.GetKeyUp(KeyCode.S))
        {
            Move(Vector3.back*MoveDistance);
            Jump();
        }
        else if(Input.GetKeyUp(KeyCode.A))
        {
            Move(Vector3.left*MoveDistance);
            Jump();
        }
        else if(Input.GetKeyUp(KeyCode.D))
        {
            Move(Vector3.right*MoveDistance);
            Jump();
        }
   }

   void MeshRotate()
   {
        if(Input.GetKeyDown(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0);
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0);
        }
   }

   private void Move(Vector3 direction)
   {
        //transform.position += direction;
        Vector3 destination = transform.position + direction;

        StartCoroutine(Leap(destination));
   }

    private IEnumerator Leap(Vector3 destination)
   {
        Vector3 startPosition = transform.position;
        float elapsed = 0f;
        float duration = 0.125f;
        while(elapsed < duration)
        {
            float t = elapsed / duration;
            transform.position = Vector3.Lerp(startPosition, destination, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = destination;
   }

   private void Jump()
   {
        rb.AddForce(0, JumpForce, 0);
   } 
}
