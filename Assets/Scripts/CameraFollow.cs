using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    GravityObject gravityObject;

    // Start is called before the first frame update
    void Start()
    {
        gravityObject = player.GetComponent<GravityObject>();
    }

    // Update is called once per frame
    void Update()
    {
        GravitySource source = gravityObject.GetGravitySource();
        Vector3 target = new Vector3(source.transform.position.x, source.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, target, 0.3f);
    }
}
