using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundOffset : MonoBehaviour
{
    Renderer[] layers;
    int maxDepth = 10;
    int focusLayer = 0;

    private void Awake() {
        List<Renderer> list = new List<Renderer>();

        for (int i = 0; i < transform.childCount; i ++) {
            if (transform.GetChild(i).gameObject.layer == LayerMask.NameToLayer("Background")){
                list.Add(transform.GetChild(i).GetComponent<Renderer>());
            }
        }
        layers = list.ToArray();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 camPos = Camera.main.transform.position;
        foreach (Renderer layer in layers) {
            float depth = (focusLayer - layer.sortingOrder) / (float)maxDepth;
            layer.transform.position = new Vector3(camPos.x * depth, camPos.y * depth, transform.position.z);
        }
    }
}
