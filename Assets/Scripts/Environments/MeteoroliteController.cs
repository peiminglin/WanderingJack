using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoroliteController : MonoBehaviour
{
    Rigidbody2D myRig;
    Material myMat;
    float timer;
    Vector3 center;
    float maxDist;
    public float power;
    int attack;

    // Start is called before the first frame update
    void Start(){
        transform.localScale = Vector3.one * Random.Range(0.5f, 1.5f);
        myMat = GetComponent<Renderer>().material;
        myRig = GetComponent<Rigidbody2D>();
        myRig.AddForce(Random.insideUnitCircle, ForceMode2D.Impulse);
        timer = -1f;
    }

    // Update is called once per frame
    void Update(){
        transform.Rotate(Vector3.forward, 0.1f);

        if (Vector3.Distance(transform.position, center) > maxDist){
            transform.position = center;
        }

        //power = myRig.velocity.magnitude * transform.localScale.magnitude * transform.localScale.magnitude / 4;
        power = 0;
        if ((int)power != attack){
            StartCoroutine(WaitAndSetAttack((int)power));
        }
    }

    public void SetCenter(Vector3 center, float radius){
        this.center = center;
        this.maxDist = radius;
    }

    public int GetAttack(){
        return attack;
    }

    IEnumerator WaitAndSetAttack(int value){
        yield return new WaitForSeconds(0.1f);
        attack = value;
        myMat.color = value > 0 ? Color.red : Color.white;
    }

    public void FallAfter(float time){
        Invoke("Fall", time);
    }

    void Fall(){
        myRig.AddForce(Random.insideUnitCircle, ForceMode2D.Impulse);
    }
}
