using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerup : MonoBehaviour
{
    [SerializeField] float rotationRate = 30f;
    [SerializeField] ParticleSystem collectParticles;

    public GameObject powerup;
    BoxCollider hitbox;
    MeshRenderer body;
    MeshRenderer arrow1;
    MeshRenderer arrow2;
    AudioSource aud;
    void Start()
    {
        body = GetComponentsInChildren<MeshRenderer>(gameObject)[0];
        arrow1 = GetComponentsInChildren<MeshRenderer>(gameObject)[1];
        arrow2 = GetComponentsInChildren<MeshRenderer>(gameObject)[2];
        hitbox = GetComponent<BoxCollider>();
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationRate * Time.deltaTime, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collectParticles.Play();
            aud.Play();
            // turns off all the MeshRenderers of the powerup and the BoxCollider as well
            body.enabled = hitbox.enabled = arrow1.enabled = arrow2.enabled = false;
        }
    }
}
