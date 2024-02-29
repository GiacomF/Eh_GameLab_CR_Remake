using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class OffScreenTrigger : MonoBehaviour
{
    public Transform cameraTransform;
    public CameraMovement gameCamera;

    void Update()
    {
        gameObject.transform.SetParent(cameraTransform);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            gameCamera.OffCameraCheck();
        }

        if (other.CompareTag("Tile"))
        {
            Debug.Log("impacted");
            LevelScript.instance.Generate = true;
        }
    }
}
