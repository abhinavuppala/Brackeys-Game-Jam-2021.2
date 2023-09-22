using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] float reloadLevelDelay = 2f;
    [SerializeField] float nextLevelDelay = 3f;

    [SerializeField] ParticleSystem explosion;
    [SerializeField] ParticleSystem finish;
    [SerializeField] ParticleSystem land;
    [SerializeField] ParticleSystem movementPowerup;
    [SerializeField] ParticleSystem jumpPowerup;

    MeshRenderer mesh;

    bool alive = true;
    
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                if (alive)
                {
                    land.Play();
                }
                break;
            case "Lava":
                if (alive)
                {
                    explosion.Play();
                    mesh.enabled = false;
                    alive = false;
                    movementPowerup.Stop();
                    jumpPowerup.Stop();
                    Invoke("ReloadLevel", reloadLevelDelay);
                }
                break;
            case "Deadly":
                if (alive)
                {
                    explosion.Play();
                    mesh.enabled = false;
                    alive = false;
                    movementPowerup.Stop();
                    jumpPowerup.Stop();
                    Invoke("ReloadLevel", reloadLevelDelay);
                }
                break;
            case "Movement Powerup":
                movementPowerup.Play();
                break;
            case "Jump Powerup":
                jumpPowerup.Play();
                break;
            case "Finish":
                if (alive)
                {
                    finish.Play();
                    Invoke("LoadNextLevel", nextLevelDelay);
                }
                break;
            default:
                break;
        }
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        // to do - if the current scene is the last in the index, then go to the main menu scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex + 1 == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
