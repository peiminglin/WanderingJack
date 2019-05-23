using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundOffset : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector2 camPos = Camera.main.transform.position;
        transform.position = new Vector3(camPos.x * 0.8f, camPos.y * 0.8f, transform.position.z);
    }
}
