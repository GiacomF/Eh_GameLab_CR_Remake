using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerTransform;
    public EagleEnemy EagleEnemy;
    public V3_PlayerController player;
    public float speed;
    public float Timer;
    public float maxTimer = 5f;
    public float cameraKeepsGoing = 0.4f;
    bool canWin = true;
    Vector3 offset = new Vector3(4,6,-4);

    void Start()
    {
        Timer = maxTimer;
        transform.position = playerTransform.position + offset;
    }

    void Update()
    {
        if(!GameStateManager.instance.gameIsPaused)
        {
            if(canWin)
            {
                if(player.isIdle)
                {
                    Timer -= Time.deltaTime;
                    if(Timer <= 0)
                    {
                        Debug.Log("Time's up!");
                        transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0,0,cameraKeepsGoing), speed*Time.deltaTime);
                    }
                }
                else
                {
                    Timer = maxTimer;
                    transform.position = Vector3.Lerp(transform.position, playerTransform.position + offset, speed*Time.deltaTime);
                }
            }
        }
    }

    public void OffCameraCheck()
    {
        Debug.Log("Player off camera");
        EagleEnemy.getPlayer = true;
    }
}
