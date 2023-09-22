using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishSound : MonoBehaviour
{
    AudioSource aud;
    
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            aud.Play();
        }
    }
}
