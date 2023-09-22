using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float jumpHeight = 10f;
    [SerializeField] float moveSpeed = 0.1f;
    [SerializeField] float moveMultiplier = 2f;
    [SerializeField] float jumpMultiplier = 2f;

    int jumpsAvailable = 1;
    int maxJumpsAvailable = 1;

    bool controlsEnabled = true;

    // caching reference
    Rigidbody rb;
    AudioSource aud;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aud = GetComponent<AudioSource>();
    }

    // FixedUpdate runs exactly 50 times per second, good for physics
    void FixedUpdate()
    {
        if (controlsEnabled)
        {
            rb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y, 0);

            // jumps if you are able to and allows for 2x jump
            if (Input.GetKey(KeyCode.Space) & jumpsAvailable > 0)
            {
                rb.AddForce(Vector3.up * jumpHeight);
                jumpsAvailable--;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // resets jumps to max when hitting the ground, allows for 2x jump
        if (collision.gameObject.tag == "Ground")
        {
            aud.Play();
            jumpsAvailable = maxJumpsAvailable;
        }
        else if (collision.gameObject.tag == "Movement Powerup")
        {
            moveSpeed *= moveMultiplier;
        }
        else if (collision.gameObject.tag == "Jump Powerup")
        {
            jumpHeight *= jumpMultiplier;
        }
        else if (collision.gameObject.tag == "Finish")
        {
            controlsEnabled = false;
        }
        else if (collision.gameObject.tag == "Lava")
        {
            controlsEnabled = false;
        }
    }
}
