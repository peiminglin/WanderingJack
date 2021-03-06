﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathPlanet : MonoBehaviour
{
    [SerializeField]
    float minScale = 1f;
    [SerializeField]
    float maxScale = 1.5f;
    [SerializeField]
    float speed = 0.1f;

    float currentScale;

    int trigger = 1;

    // Start is called before the first frame update
    void Start()
    {
        currentScale = transform.localScale.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        currentScale += trigger * Time.deltaTime * speed;
        if (currentScale > maxScale){
            currentScale = maxScale;
            trigger = -trigger;
        }else if (currentScale < minScale){
            currentScale = minScale;
            trigger = -trigger;
        }

        transform.localScale = new Vector3(currentScale, currentScale, 1);
    }
}
