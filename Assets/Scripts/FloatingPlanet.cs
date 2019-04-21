using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlanet : MonoBehaviour
{
    [SerializeField]
    Vector3[] points;

    int nextId;
    int currentId;
    float dist;
    float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        currentId = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, points[nextId]) < float.Epsilon){
            currentId = nextId;
            nextId = (nextId + 1) % points.Length;
            dist = 0f;
        }

        dist += Time.deltaTime;

        transform.position = Vector3.Lerp(points[currentId], points[nextId], dist*speed);
    }
}
