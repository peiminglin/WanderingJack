using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reptile : MonoBehaviour
{
    float dir;
    float speed = 0.03f;
    // Start is called before the first frame update
    void Start()
    {
        dir = Random.Range(0f, 1f) > 0.5f ? 1 : -1;
        if (dir > 0) {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.parent.position, Vector3.forward * dir, speed);
    }
}
