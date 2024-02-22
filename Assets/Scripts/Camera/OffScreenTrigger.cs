using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScreenTrigger : MonoBehaviour
{
    public CameraMovement gameCamera;
    void OnTriggerEnter(Collider other)
    {
        gameCamera.OffCameraCheck();
    }
}
