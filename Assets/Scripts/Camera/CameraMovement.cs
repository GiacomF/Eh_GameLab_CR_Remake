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
    public float cameraKeepsGoing = 0.04f;
    bool canWin = true;
    Vector3 offset = new Vector3(5,7,-4);

    void Start()
    {
        Timer = maxTimer;
    }

    void Update()
    {
        if(canWin)
        {
            if(player.isIdle)
            {
                Timer -= Time.deltaTime;
                if(Timer <= 0)
                {
                    transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0,0,cameraKeepsGoing), speed);
                }
            }
            else
            {
                Timer = maxTimer;
                transform.position = Vector3.Lerp(transform.position, playerTransform.position + offset, speed);
            }
        }
    }

    public void OffCameraCheck()
    {
        EagleEnemy.getPlayer = true;
    }
}
