using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkEnemy : Enemy
{
    public Transform target;
    public float chase_radius;
    public float attack_radius;
    public Vector3 home_pos;
    //public GameObject bullet;
    public float firerate;
    public float next_fire;
    GravityObject myGo;

    public float firepoint;

    // Start is called before the first frame update
    void Start()
    {
        next_fire = Time.time;
        home_pos = transform.position;
        myGo = GetComponent<GravityObject>();
        //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), bullet.GetComponent<Collider2D>());
        //target = GameObject.FindWithTag("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        Vector3 myPos = transform.position;
        Vector3 playerPos = target.position;
        if (Vector3.Distance(myPos, playerPos) <= chase_radius && Vector3.Distance(myPos, playerPos) > attack_radius)
        {
            myGo.Orbit(1f, speed);
            //transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            /*if (myPos.y > playerPos.y && myPos.x > playerPos.x)
            {
                myGo.Orbit(1f, speed);
            }*/
        }
    }
}
