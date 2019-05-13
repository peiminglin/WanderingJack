using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : Enemy
{
    public Transform target;
    public float chase_radius;
    public float attack_radius;
    public Transform home_pos;
    public GameObject bullet;
    public float firerate;
    public float next_fire;

 
    // Start is called before the first frame update
    void Start()
    {
        next_fire = Time.time;
        //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), bullet.GetComponent<Collider2D>());
        //target = GameObject.FindWithTag("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
        CheckTimeToFire();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position)<=chase_radius && Vector3.Distance(target.position, transform.position)>attack_radius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    void CheckTimeToFire()
    {
        if (Time.time > next_fire && Vector3.Distance(target.position, transform.position) <= attack_radius)
        {
            Vector3 position = transform.position;
            position.y += -1;
            Instantiate(bullet, position, Quaternion.identity);
            next_fire = Time.time + firerate;
        }
    }
}
