using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoFire : MonoBehaviour
{
    Rigidbody2D myRig;
    float existTime = 5f;

    // Start is called before the first frame update
    void Start(){
        myRig = GetComponent<Rigidbody2D>();
        //Vector2 dir;
        //while (Vector2.Angle(dir = Random.insideUnitCircle, transform.up.To2d())>90){}
        //myRig.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
    }

    public void Poo(Vector2 dir){
        myRig.AddForce(dir * 7f, ForceMode2D.Impulse);
    }

    private void Update() {
        existTime -= Time.deltaTime;
        if (existTime < 0){
            Destroy(this.gameObject);
        }
    }
}
