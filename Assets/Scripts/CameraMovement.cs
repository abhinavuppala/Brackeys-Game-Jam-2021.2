using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float cameraDelay = 2f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("StartCameraMovement", cameraDelay);
    }

    void StartCameraMovement()
    {
        transform.Translate(Vector3.right * Time.deltaTime * movementSpeed);
    }
}
