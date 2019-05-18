using System.Collections;
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
    float defaultScale;

    float currentScale;

    int offset = 1;

    // Start is called before the first frame update
    void Start()
    {
        defaultScale = transform.localScale.x;
        currentScale = defaultScale;
        Debug.Log(defaultScale);
    }

    // Update is called once per frame
    void Update()
    {
        currentScale += offset * Time.deltaTime * speed;
        if (currentScale > maxScale * defaultScale){
            currentScale = maxScale * defaultScale;
            offset = -offset;
        }else if (currentScale < minScale * defaultScale) {
            currentScale = minScale * defaultScale;
            offset = -offset;
        }

        transform.localScale = new Vector3(currentScale, currentScale, 1);
    }
}
