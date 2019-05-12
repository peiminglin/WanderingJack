using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorController : MonoBehaviour
{
    [SerializeField]
    float speed = 50f;
    [SerializeField]
    float jumpingPower = 5f;
    float movingDir;
    Rigidbody2D myRig;
    Animator animator;
    bool isLanded;
    public bool IsLanded{ get { return isLanded; } set { isLanded = value; }}
    GravityObject gravityObject;
    Vector3 currentOffset;

    void Awake()
    {
        myRig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gravityObject = GetComponent<GravityObject>();
    }

    // Update is called once per frame
    void Update()
    {
        movingDir = Input.GetAxisRaw("Horizontal");
        if (isLanded) {
            //gravityObject.SetCurrentOffset();

            if (Input.GetButtonDown("Jump")) {
                myRig.AddForce(transform.up * jumpingPower, ForceMode2D.Impulse);
                isLanded = false;
            }
        }

        if (Mathf.Abs(movingDir) > float.Epsilon){
            if (!gravityObject.IsFloating){
                gravityObject.Orbit(movingDir, speed * Time.deltaTime);
            }
        }

        animator.SetBool("IsGrounded", isLanded);
        animator.SetBool("IsWalking", System.Math.Abs(movingDir) > float.Epsilon);
    }

    private void FixedUpdate() {
        //Vector2 right = transform.TransformDirection(transform.right);
        //myRig.velocity += right * movingDir * speed * Time.fixedDeltaTime;
        //if (Mathf.Abs(movingDir) > float.Epsilon && !gravityObject.IsFloating)
            //gravityObject.Orbit(movingDir, speed * Time.fixedDeltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        switch(collision.gameObject.tag){
            case "Planet":
                myRig.velocity = Vector2.zero;
                isLanded = true;
                break;
            case "Stone":
                break;
        }
        //gravityObject.GetCurrentOffset();
    }

    private void OnCollisionExit2D(Collision2D collision) {
    //    isLanded = false;
    }
}
