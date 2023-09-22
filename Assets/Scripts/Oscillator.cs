using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    // no need to serialize startPos because it is constant
    Vector3 startPos;
    [SerializeField] Vector3 movementVector;

    // this lets you set the range, making it a slider in the editor
    [SerializeField] [Range(0, 1)] float movementFactor;
    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        const float tau = Mathf.PI * 2; // 2pi, approx. 6.283

        if (period <= Mathf.Epsilon) { return; } // don't do the following code if period = 0
        float cycles = Time.time / period; // constantly grows

        float rawSinWave = Mathf.Sin(cycles * tau); // gives a value of 1 to -1

        movementFactor = (rawSinWave + 1f) / 2f; // makes movementFactor go 0 to 1, not -1 to 1
        Vector3 offset = movementVector * movementFactor;
        transform.position = startPos + offset;
    }
}
