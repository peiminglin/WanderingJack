using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorController : MonoBehaviour
{
    [SerializeField]
    float speed = 1f;
    float maxSpeed = 2f;
    [SerializeField]
    float jumpingPower = 5f;
    float movingDir;
    Rigidbody2D myRig;
    bool isLanded;
    public bool IsLanded{ get { return isLanded; } set { isLanded = value; }}
    GravityObject gravityObject;

    void Awake()
    {
        myRig = GetComponent<Rigidbody2D>();
        gravityObject = GetComponent<GravityObject>();
    }

    // Update is called once per frame
    void Update()
    {
        movingDir = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && isLanded){
            myRig.AddForce(transform.up * jumpingPower, ForceMode2D.Impulse);
        }

        if (isLanded && Mathf.Abs(movingDir) > float.Epsilon && !gravityObject.IsFloating)
            gravityObject.Orbit(movingDir, speed * Time.deltaTime);

    }

    private void FixedUpdate() {
        //Vector2 right = transform.TransformDirection(transform.right);
        //myRig.velocity += right * movingDir * speed * Time.fixedDeltaTime;
        //if (Mathf.Abs(movingDir) > float.Epsilon && !gravityObject.IsFloating)
            //gravityObject.Orbit(movingDir, speed * Time.fixedDeltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        myRig.velocity = Vector2.zero;
        isLanded = true;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        isLanded = false;
    }
}
