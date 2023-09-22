using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDecay : MonoBehaviour
{
    [SerializeField] ParticleSystem decayParticles;
    [SerializeField] ParticleSystem decayExplosion;

    float lastCollision;
    bool collisionOccured = false;
    bool decayed = false;
    
    // caching references
    BoxCollider boxCollider;
    MeshRenderer meshRenderer;
    AudioSource aud;
    
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        meshRenderer = GetComponent<MeshRenderer>();
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lastCollision < Time.time - 2 & collisionOccured) // if+ it has been 2 seconds since the last collision with the obstacle
        {
            boxCollider.enabled = false;
            meshRenderer.enabled = false;
            if (!decayed)
            {
                decayed = true;
                decayExplosion.Play();
                aud.Play();
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // saves the time when the player collides with the obstacle
        if (collision.gameObject.tag == "Player")
        {
            lastCollision = Time.time;
            collisionOccured = true;
            decayParticles.Play();
        }
    }
}
