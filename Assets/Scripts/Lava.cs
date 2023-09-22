using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{

    AudioSource aud;
    
    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        aud.Play();
    }
}
