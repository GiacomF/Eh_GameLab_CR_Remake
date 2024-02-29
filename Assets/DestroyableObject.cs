using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    public AudioClip groundBreaking;
    public bool mustSplit = false;
    public float timer = 4f;
    public GameObject half1;
    public GameObject half2;
    public GameObject coll;
    Vector3 offset = new Vector3(0.25f, 0, 0);
    void Update()
    {
        if(mustSplit)
        {
            timer -= Time.deltaTime;
            Debug.Log(timer);

            if(timer <= 0)
            {
                Split();
                mustSplit = false;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            mustSplit = true;
            AudioSource.PlayClipAtPoint(groundBreaking, transform.position);
        }
    }

    void Split()
    {
        half1.transform.position -= offset;
        half2.transform.position += offset;
        coll.SetActive(false);
    }
}
