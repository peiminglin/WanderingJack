using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    [SerializeField]
    GameObject[] items;
    float radius;
    // Start is called before the first frame update
    void Start()
    {
        radius = GetComponent<CircleCollider2D>().bounds.extents.x;

        foreach (GameObject item in items) {
            int amount = Random.Range(0, 3);
            for (int i = 0; i < amount; i ++){
                Vector2 pointing = Random.insideUnitCircle.normalized;
                Vector3 pos = transform.position + (pointing * radius).To3d();
                Quaternion rot = Quaternion.FromToRotation(transform.up, pos - transform.position);
                GameObject obj = Instantiate(item, pos, rot);
                obj.transform.parent = transform;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
