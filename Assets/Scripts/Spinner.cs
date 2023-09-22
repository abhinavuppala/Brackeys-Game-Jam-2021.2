using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    
    [SerializeField] float spinRate = 50f;

    void Update()
    {
        transform.Rotate(0, spinRate * Time.deltaTime, 0);
    }
}
