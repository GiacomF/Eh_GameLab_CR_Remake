using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public AudioClip GameOverSound;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            AudioSource.PlayClipAtPoint(GameOverSound, gameObject.transform.position);
        }
    }
}
