
using UnityEngine;

public class V3_PlayerController : MonoBehaviour
{
    public float MoveDistance = 1;
    public float MoveTime = 0.4f;

    public bool isJumping = false;
    public bool jumpStart = false;
    public bool isIdle = true;
    
    public GameObject character = null;
    
    private bool isMoving = false;
    
    private Renderer visual = null;
    
    Vector3 movDir;

    void Start()
    {
        visual = character.GetComponent<Renderer>();
    }

    void Update()
    {
        if (!GameStateManager.instance.gameIsPaused)
        {
            CanIdle();
            CanMove();
        }
    }

    void CanIdle()
    {
        if(isIdle)
        {
            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
            {
                movDir.z = Input.GetAxisRaw ("Vertical");
                SetMove();
            }
            else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                movDir.x = Input.GetAxisRaw ("Horizontal");
                SetMove();
            }
        }

        void SetMove()
        {
            isIdle = false;
            isMoving = true;
            jumpStart = true;
        }
    }

    void CanMove()
    {
        if(isMoving)
        {
            if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                isJumping = true;
                Moving(new Vector3(transform.position.x, transform.position.y, transform.position.z + movDir.z));
            }
            else if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                isJumping = true;
                Moving(new Vector3(transform.position.x + movDir.x, transform.position.y, transform.position.z));
            }
        }
    }
    void Moving(Vector3 pos)
    {
        isIdle = false;
        isMoving = false;
        jumpStart = false;
        LeanTween.move(this.gameObject, pos, MoveTime).setOnComplete(MoveComplete);
    }
    
    void MoveComplete()
    {
        isIdle = true;
        isMoving = false;
        isJumping = false;
        jumpStart = false;
    }
}
