﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : Enemy
{
    public Transform target;
    public float chase_radius;
    public float attack_radius;
    public Vector3 home_pos;
    public GameObject bullet;
    public float firerate;
    public float next_fire;

    public float firepoint;

    // Start is called before the first frame update
    void Start()
    {
        next_fire = Time.time;
        home_pos = transform.position;
        //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), bullet.GetComponent<Collider2D>());
        //target = GameObject.FindWithTag("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null){
            GameObject go = GameObject.FindWithTag("Player");
            if (go != null)
                target = go.transform;
        }else{
            CheckDistance();
            CheckTimeToFire();
        }

    }

    void CheckDistance()
    {
        float RayLength = chase_radius - (attack_radius * 1.1f);
        //LayerMask mask = LayerMask.GetMask("Steppable");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, target.position, RayLength);
        //float distance_to_planet = 99;
        //Vector3 avoid_col;
        if (hit.collider == null)
        {
            if (Vector3.Distance(target.position, transform.position) <= chase_radius && Vector3.Distance(target.position, transform.position) > attack_radius)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else if (Vector3.Distance(target.position, transform.position) > chase_radius)
            {
                transform.position = Vector3.MoveTowards(transform.position, home_pos, speed * Time.deltaTime);
            }
        }
    }

    void CheckTimeToFire()
    {
        if (Time.time > next_fire && Vector3.Distance(target.position, transform.position) <= attack_radius)
        {
            Vector3 position = transform.position;
            position.y += firepoint;
            Instantiate(bullet, position, Quaternion.identity);
            next_fire = Time.time + firerate;
        }
    }
}
