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
    GravityObject go;
    public bool isFloating;
    float floatingTime;
    float maxFloatingTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        myRig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        go = GetComponent<GravityObject>();
        isFloating = go.IsFloating;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFloating){
            if (isFloating != go.IsFloating){
                isFloating = false;
            }else{
                floatingTime += Time.deltaTime;
                if (floatingTime > maxFloatingTime) {
                    Hurt(null, health);
                }
            }
        } else{
            if (isFloating != go.IsFloating){
                isFloating = true;
                floatingTime = 0;
            }
        }
    }

    public void StartFloat(){
        //isFloating = true;
        floatingTime = 0;
    }

    public void Hurt(GameObject source = null, int damage = 1){
        Debug.Log("Ouch!");
        if (health > 0){
            health -= damage;
            if (source != null){
                myRig.AddForce((transform.position - source.transform.position).normalized * 500f, ForceMode2D.Impulse);
            }
            animator.SetTrigger("GetHurt");
            animator.SetInteger("Health", health < 0 ? 0 : health);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        string objectTag = collision.gameObject.tag;
        switch (objectTag){
            case "Stone":
                Rigidbody2D stone = collision.gameObject.GetComponent<Rigidbody2D>();
                if (stone.velocity.magnitude > 5f){
                    Hurt(stone.gameObject);
                }
                break;
            case "Saw":
            case "Bullet":
                Hurt(collision.gameObject);
                break;
            default:
                break;
        }
    }
}
