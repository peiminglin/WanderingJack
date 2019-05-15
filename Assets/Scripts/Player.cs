using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public int health = 3;
    public bool isFloating;
    int status = 0;
    Rigidbody2D myRig;
    Animator animator;
    GravityObject go;
    float floatingTime;
    float maxFloatingTime = 5f;
    int totalCollectable = 4;
    int collected;

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

    public void Collect(){
        collected++;
        if (collected >= totalCollectable){
            LevelManager.GoalReached();
        }
    }

    public void Hurt(GameObject source = null, int damage = 1){
        Debug.Log("Ouch!");
        if (health > 0){
            health -= damage;
            if (source != null){
                myRig.AddForce((transform.position - source.transform.position).normalized * 5f, ForceMode2D.Impulse);
            }
            animator.SetTrigger("GetHurt");
            animator.SetInteger("Health", health < 0 ? 0 : health);
            if (health <= 0){
                Dead();
            }
        }
    }

    public void Dead(){
        LevelManager.Restart();
    }

    public bool IsDead(){
        return health <= 0;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        string objectTag = collision.gameObject.tag;
        switch (objectTag){
            case "Stone":
                MeteoroliteController stone = collision.gameObject.GetComponent<MeteoroliteController>();
                int attack = stone.GetAttack();
                if (attack > 0){
                    Hurt(collision.gameObject, attack);
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
