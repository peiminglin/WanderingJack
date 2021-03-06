﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoFire : MonoBehaviour
{
    //Rigidbody2D myRig;
    [SerializeField]
    float existTime = 3f;

    // Start is called before the first frame update
    void Start(){
        //myRig = GetComponent<Rigidbody2D>();
        //float power = 4f * myRig.mass;
        //Vector2 dir = transform.parent.transform.up;
        ////while (Vector2.Angle(dir = Random.insideUnitCircle, transform.up.To2d())>90){}
        //myRig.AddForce(dir.Rotate(Random.Range(-75f, 75f))* power, ForceMode2D.Impulse);
    }

    private void Update() {
        existTime -= Time.deltaTime;
        if (existTime < 0){
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag.Equals("Player")){
            Destroy(this.gameObject);
        }
    }
}
