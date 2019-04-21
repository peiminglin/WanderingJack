using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlanet : MonoBehaviour
{
    [SerializeField]
    bool isClock = true;

    float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.forward, speed * Time.deltaTime);
    }
}
