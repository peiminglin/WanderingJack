﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySource : MonoBehaviour {

    [SerializeField]
    float power;
    public float Power { 
        get { return power; } 
        set { power = value; }
    }
    //Transform planet;
    float planetRadius;
    CircleCollider2D col;
    float radius;
    public float Radius {
        get { return radius; }
        set { radius = value; }
    }

    private void Awake() {
        //planet = GetComponentInParent<Transform>();
        col = transform.parent.GetComponent<CircleCollider2D>();
        planetRadius = col.bounds.extents.x * col.transform.localScale.magnitude;
    }

    private void Update() {
        radius = planetRadius;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Player")){
            if (!collision.gameObject.GetComponent<CharactorController>().IsLanded)
                collision.gameObject.GetComponent<GravityObject>().UseGravity(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag.Equals("Player")) {
            GravityObject go = collision.gameObject.GetComponent<GravityObject>();
            if (go.GetGravitySource().Equals(this)) {
                go.ResetGravity();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        //if (collision.tag.Equals("Player")) {
        //    GravityObject go = collision.gameObject.GetComponent<GravityObject>();
        //    if (go.GetGravitySource() == null) {
        //        go.UseGravity(this);
        //    }
        //}
    }
}
