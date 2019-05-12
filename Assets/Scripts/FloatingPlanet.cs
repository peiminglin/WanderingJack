using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlanet : MonoBehaviour
{
    [SerializeField]
    Vector3[] offsets;
    [SerializeField]
    float speed = 0.1f;

    int nextId;
    //int currentId;
    Vector3 currentPos = new Vector3();
    Vector3 nextPos = new Vector3();
    float dist;

    // Start is called before the first frame update
    void Start(){
        //currentId = 0;
        if (offsets.Length == 0){
            offsets = new Vector3[]{Vector3.zero};
        }
        currentPos = transform.position;
        nextPos = currentPos;
        nextId = offsets.Length-1;
    }

    // Update is called once per frame
    void Update(){
        if (Vector3.Distance(transform.position, nextPos) < float.Epsilon){
            //currentId = nextId;
            currentPos = nextPos;
            nextId = (nextId + 1) % offsets.Length;
            nextPos = currentPos + offsets[nextId];
            dist = 0f;
        }

        dist += Time.deltaTime;
        transform.position = Vector3.Lerp(currentPos, nextPos, dist * speed);
    }
}
