using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlanet : MonoBehaviour
{
    [SerializeField]
    bool clockwise = true;
    [SerializeField]
    float speed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        //transform.RotateAround(Vector3.forward, speed * Time.deltaTime);
        int dir = clockwise ? -1 : 1;
        transform.Rotate(Vector3.forward, speed * dir * Time.deltaTime);
    }
}
