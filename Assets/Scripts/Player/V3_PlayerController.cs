
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class V3_PlayerController : MonoBehaviour
{
    public float MoveDistance = 1;
    public float MoveTime = 0.4f;
    public float timer;
    public float maxTimer;

    public bool isIdle = true;
    public bool isMoving = false;
    public bool isJumping = false;
    public bool jumpStart = false;
    public bool isInvincible = false;
    public GameObject character = null;
    public Transform PlayerSpawn;
    Vector3 movDir;

    private AnimatorController animatorController;
    void Start()
    {
        animatorController = gameObject.GetComponentInChildren<AnimatorController>();
    }

    void Update()
    {
        if(!GameStateManager.instance.gameIsPaused)
        {
            if(isInvincible)
            {
                timer+= Time.deltaTime;
                if(timer>=maxTimer)
                {
                    isInvincible = false;
                    timer = 0f;
                }
            }

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

        LeanTween.move(this.gameObject, RoundVector(pos), MoveTime).setOnComplete(MoveComplete);
    }

    Vector3 RoundVector(Vector3 input)
    {
        Vector3 output;
        output.x = Mathf.Round(input.x);
        output.y = Mathf.Round(input.y);
        output.z = Mathf.Round(input.z);
        return output;
    }
    
    void MoveComplete()
    {
        isIdle = true;
        isMoving = false;
        isJumping = false;
        jumpStart = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            animatorController.splatPlayer();
            GameStateManager.instance.SetCurrentGameState(GameStates.GameOver);
        }
    }
}
