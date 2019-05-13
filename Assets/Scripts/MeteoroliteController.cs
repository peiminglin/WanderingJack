using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoroliteController : MonoBehaviour
{
    Rigidbody2D myRig;
    float timer;
    Vector3 center;
    float maxDist;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.one * Random.Range(0.5f, 1.5f);
        myRig = GetComponent<Rigidbody2D>();
        myRig.AddForce(Random.insideUnitCircle, ForceMode2D.Impulse);
        timer = -1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, 0.1f);
        if (timer > 0){
            timer -= Time.deltaTime;
            if (timer < 0){
                Fall();
            }
        }

        if (Vector3.Distance(transform.position, center) > maxDist){
            transform.position = center;
        }
    }

    public void SetCenter(Vector3 center, float radius){
        this.center = center;
        this.maxDist = radius;
    }

    public void FallAfter(float time){
        timer = time;
    }

    void Fall(){
        myRig.AddForce(Random.insideUnitCircle * 150f, ForceMode2D.Impulse);
    }
}
