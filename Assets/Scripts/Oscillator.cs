﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector=new Vector3(10f,10f,10f);
    [SerializeField] private float period = 2f;

    [Range(0, 1)] [SerializeField] private float movementFactor;
    private Vector3 startingPos;
    void Start()
    {
        startingPos = transform.position;
    }

    void Update()
    {
        if(period <= Mathf.Epsilon){ return;}
        float cycles = Time.time / period; 

        const float tau = Mathf.PI * 2f;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = movementFactor * movementVector;
        transform.position = startingPos + offset;
    }
}
