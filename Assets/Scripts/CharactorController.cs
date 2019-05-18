using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorController : MonoBehaviour
{
    [SerializeField]
    LayerMask steppableLayer;
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float jumpingPower = 5f;
    float movingDir;
    Rigidbody2D myRig;
    Animator animator;
    //bool isLanded;
    public bool IsLanded { get; set; }
    GravityObject gravityObject;
    Player player;
    Vector3 currentOffset;
    float groundDist;
    float bodyExtents;
    float airFriction = 0.95f;

    void Awake()
    {
        myRig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gravityObject = GetComponent<GravityObject>();
        player = GetComponent<Player>();
        BoxCollider2D body = GetComponent<BoxCollider2D>();
        groundDist = body.bounds.extents.y + 0.1f;
        bodyExtents = body.bounds.extents.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.IsDead()){
            return;
        }

        movingDir = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.LeftControl) ? 0 : Input.GetAxisRaw("Horizontal");
        if (IsLanded) {
            if (Input.GetButtonDown("Jump")){
                Vector2 jumpDir = transform.up.To2d().Rotate(30 * movingDir);
                myRig.AddForce(jumpDir * jumpingPower, ForceMode2D.Impulse);
                //myRig.AddForce(transform.right * movingDir * speed * myRig.mass, ForceMode2D.Impulse);
                //isLanded = false;
            }
            if (Mathf.Abs(movingDir) > float.Epsilon) {
                gravityObject.Orbit(movingDir, speed * Time.deltaTime);
                //myRig.AddForce(transform.right * movingDir * speed * myRig.mass);
            }
        }

        if (!player.IsFloating){
            myRig.AddForce(transform.right * movingDir * myRig.mass * speed);
        }else if (Input.GetButton("Jump") && player.Enegy > 0){
            myRig.AddForce(transform.up * myRig.mass * 10);
            player.Enegy--;
        }
        //Vector2 fallV = myRig.velocity.ComponentOn(gravityObject.GetGravity());
        //Vector2 sideV = myRig.velocity - fallV;
        //if (sideV.magnitude > speed) {
        //    sideV = sideV.SetMagnitude(speed);
        //}else{
        //    //sideV *= airFriction;
        //}

        //if (Input.GetKeyDown(KeyCode.T)){
        //}

        //myRig.velocity = fallV + sideV;
        //if (Mathf.Abs(movingDir) > float.Epsilon){
        //    if (!gravityObject.IsFloating){
        //        gravityObject.Orbit(movingDir, speed * Time.deltaTime);
        //    }
        //}

        animator.SetBool("IsGrounded", IsLanded);
        animator.SetBool("IsWalking", System.Math.Abs(movingDir) > float.Epsilon);
    }

    private void FixedUpdate() {
        //Vector2 right = transform.TransformDirection(transform.right);
        //myRig.velocity += right * movingDir * speed * Time.fixedDeltaTime;
        //if (Mathf.Abs(movingDir) > float.Epsilon && !gravityObject.IsFloating)
        //gravityObject.Orbit(movingDir, speed * Time.fixedDeltaTime);
        bool prevGrounded = IsLanded;
        GroundCheck();
        if (!prevGrounded && IsLanded){
            //myRig.velocity = myRig.velocity * 0.5f;
        }
    }

    void GroundCheck(){
        Debug.DrawRay(transform.position, -transform.up* groundDist, Color.green);
        IsLanded = Physics2D.Raycast(transform.position, -transform.up, groundDist, steppableLayer) ||
                   Physics2D.Raycast(transform.position + (transform.right * bodyExtents), -transform.up, groundDist, steppableLayer) ||
                   Physics2D.Raycast(transform.position + (transform.right * -bodyExtents), -transform.up, groundDist, steppableLayer);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        switch(collision.gameObject.tag){
            case "Planet":
                myRig.velocity = Vector2.zero;
                IsLanded = true;
                break;
            default:
                break;
        }
        //gravityObject.GetCurrentOffset();
    }

    //private void OnCollisionExit2D(Collision2D collision) {
    ////    isLanded = false;
    //}
}
