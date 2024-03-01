using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    public AudioClip groundBreaking;
    
    public bool mustSplit = false;
    public float timeToSplit = 1f;
    
    public GameObject half1;
    public GameObject half2;
    
    public BoxCollider coll;

    private bool isBreaking = false;

    Vector3 offset = new Vector3(0.25f, 0, 0);

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (!isBreaking)
            { 
                StartCoroutine(waitAndSplit());
            }
            AudioSource.PlayClipAtPoint(groundBreaking, transform.position);
        }
    }

    void Split()
    {
        Object.Destroy(coll);
        half1.SetActive(false);
    }

    private IEnumerator waitAndSplit() 
    {
        isBreaking = true;
        yield return new WaitForSeconds(timeToSplit);
        Split();
    }
}
