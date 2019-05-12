using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    int health = 3;
    int status = 0;
    Rigidbody2D myRig;
    [SerializeField]
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        myRig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hurt(GameObject source, int damage = 1){
        health -= damage;
        myRig.AddForce((transform.position - source.transform.position).normalized * 500f, ForceMode2D.Impulse);
        animator.SetTrigger("GetHurt");
        animator.SetInteger("Health", health);
    }
}
