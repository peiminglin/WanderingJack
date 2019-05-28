using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {
    public int maxHealth = 5;
    public int Health { get; set; }

    public float maxEnergy = 100f;
    public float Energy;// { get; set; }
    public float EnergyRecoverRate = 1f;

    public bool IsFloating { get; set; }

    //int status = 0;
    Rigidbody2D myRig;
    Material myMat;
    Animator animator;
    GravityObject go;
    float floatingTime;
    readonly float maxFloatingTime = 5f;
    readonly int totalCollectable = 4;
    int collected;
    bool isInvincible;
    Thinking thinking;
    //readonly float invincibleTime = 3f;

    // Start is called before the first frame update
    void Start() {
        myMat = GetComponent<Renderer>().material;
        myRig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        go = GetComponent<GravityObject>();
        thinking = transform.GetChild(0).GetComponent<Thinking>();
        IsFloating = go.IsFloating;
        InvincibleFor(3f);
        Health = maxHealth;
        Energy = maxEnergy;
    }

    // Update is called once per frame
    void Update() {
        Energy += Time.deltaTime * EnergyRecoverRate;
        if (Energy > maxEnergy) {
            Energy = maxEnergy;
        }

        if (IsFloating) {
            if (IsFloating != go.IsFloating) {
                IsFloating = false;
            } else {
                floatingTime += Time.deltaTime;
                if (floatingTime > maxFloatingTime) {
                    Attacked(null, Health);
                }
            }
        } else {
            if (IsFloating != go.IsFloating) {
                IsFloating = true;
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
            thinking.Next();
            LevelManager.GoalReached();
        }
    }

    public void Attacked(GameObject source = null, int damage = 1) {
        if (!isInvincible && Health > 0) {
            GetHurt(source, damage);
        }
    }

    void GetHurt(GameObject source = null, int damage = 1) {
        Debug.Log("Ouch!");
        if (Health > 0) {
            Health -= damage;
            if (source != null) {
                myRig.AddForce((transform.position - source.transform.position).normalized * 100f, ForceMode2D.Impulse);
                Debug.Log("Hit me");
            }
            animator.SetTrigger("GetHurt");
            animator.SetInteger("Health", Health < 0 ? 0 : Health);
            if (Health <= 0) {
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
        return Health <= 0;
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
