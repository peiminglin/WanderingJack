using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Transform target;
    public Vector2 move_direction;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        //transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        move_direction = (target.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(move_direction.x, move_direction.y);
        Destroy(gameObject, 3f);
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Debug.Log("hitted");
            col.gameObject.GetComponent<Player>().Attacked();
            Destroy(gameObject);
        }
    }

        // Update is called once per frame
        void Update()
    {
    }
}
