using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlanet : MonoBehaviour
{
    [SerializeField]
    Vector3[] points;
    [SerializeField]
    float speed = 0.1f;

    int nextId;
    int currentId;
    float dist;

    // Start is called before the first frame update
    void Start()
    {
        currentId = 0;
        points[0] = transform.position;
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
