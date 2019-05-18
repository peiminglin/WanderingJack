using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {
    public int health = 3;
    public bool isFloating;
    int status = 0;
    Rigidbody2D myRig;
    Material myMat;
    Animator animator;
    GravityObject go;
    float floatingTime;
    float maxFloatingTime = 5f;
    int totalCollectable = 4;
    int collected;
    bool isInvincible;

    // Start is called before the first frame update
    void Start() {
        myMat = GetComponent<Renderer>().material;
        myRig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        go = GetComponent<GravityObject>();
        isFloating = go.IsFloating;
        InvincibleFor(3f);
    }

    // Update is called once per frame
    void Update() {
        if (isFloating) {
            if (isFloating != go.IsFloating) {
                isFloating = false;
            } else {
                floatingTime += Time.deltaTime;
                if (floatingTime > maxFloatingTime) {
                    Attacked(null, health);
                }
            }
        } else {
            if (isFloating != go.IsFloating) {
                isFloating = true;
                floatingTime = 0;
            }
        }
    }

    public void StartFloat() {
        //isFloating = true;
        floatingTime = 0;
    }

    public void Collect() {
        collected++;
        if (collected >= totalCollectable) {
            LevelManager.GoalReached();
        }
    }

    public void Attacked(GameObject source = null, int damage = 1) {
        if (!isInvincible && health > 0) {
            GetHurt(source, damage);
        }
    }

    void GetHurt(GameObject source = null, int damage = 1) {
        Debug.Log("Ouch!");
        if (health > 0) {
            health -= damage;
            if (source != null) {
                myRig.AddForce((transform.position - source.transform.position).normalized * 5f, ForceMode2D.Impulse);
            }
            animator.SetTrigger("GetHurt");
            animator.SetInteger("Health", health < 0 ? 0 : health);
            if (health <= 0) {
                Dead();
            } else {
                InvincibleFor(2f);
            }
        }
    }

    public void Dead() {
        LevelManager.Restart();
    }

    public void InvincibleFor(float time) {
        isInvincible = true;
        myMat.color = myMat.color.SetAlpha(0.5f);
        StartCoroutine(InvincibleLast(time));
    }

    IEnumerator InvincibleLast(float time) {
        yield return new WaitForSeconds(time);
        isInvincible = false;
        myMat.color = myMat.color.SetAlpha(1);
    }

    public bool IsDead() {
        return health <= 0;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        string objectTag = collision.gameObject.tag;
        switch (objectTag) {
            case "Stone":
                MeteoroliteController stone = collision.gameObject.GetComponent<MeteoroliteController>();
                int attack = stone.GetAttack();
                if (attack > 0) {
                    Attacked(collision.gameObject, attack);
                }
                break;
            case "Saw":
            case "Bullet":
                Attacked(collision.gameObject);
                break;
            default:
                break;
        }
    }
}
