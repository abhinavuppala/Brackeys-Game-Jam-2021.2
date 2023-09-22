using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAudio : MonoBehaviour
{
    bool audioOn = true;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if(audioOn)
            {
                audioOn = false;
                AudioListener.volume = 0f;
            }
            else
            {
                audioOn = true;
                AudioListener.volume = 100f;
            }
        }
    }
}
