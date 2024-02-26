using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerTransform;
    public EagleEnemy EagleEnemy;
    public V3_PlayerController player;

    public float baseLerpingSpeed = 0.5f;
    public float increasedLerpingSpeed = 1.5f;

    public float cameraKeepsGoing = 10f;
    public float maxPlayerDistance = 4f;

    private float lerpginSpeed;

    private void Start()
    {
        lerpginSpeed = baseLerpingSpeed;
    }

    void Update()
    {
        float playerDistance = playerTransform.position.z - transform.position.z;

        if (playerDistance > maxPlayerDistance)
        {
            lerpginSpeed = increasedLerpingSpeed;
        } else {
            lerpginSpeed = baseLerpingSpeed;
        }

        if(!GameStateManager.instance.gameIsPaused)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0,0,cameraKeepsGoing), lerpginSpeed);
        }
    }

    public void OffCameraCheck()
    {
        EagleEnemy.getPlayer = true;
    }
}
