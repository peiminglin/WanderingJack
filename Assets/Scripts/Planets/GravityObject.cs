using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityObject : MonoBehaviour {

    GravitySource gravitySource;
    Rigidbody2D myRig;
    Vector3 gravity = new Vector3();
    Vector3 bodyUp;
    bool isFloating;
    public bool IsFloating{ 
        get { return isFloating; } 
        set { isFloating = value; }
    }
    [SerializeField]
    float floatingSpeed = 0.3f;
    float floatDirection = 1f;
    float currentAngle;

    // Start is called before the first frame update
    void Start() {
        myRig = GetComponent<Rigidbody2D>();
        myRig.constraints = RigidbodyConstraints2D.FreezeRotation;
        myRig.gravityScale = 0f;
        //gravity = new Vector3();
        bodyUp = transform.up;
    }

    // Update is called once per frame
    void Update() {
        gravity = GetGravity();
        myRig.AddForce(gravity*myRig.mass);
        //transform.position = (transform.position - gravitySource.transform.position).normalized * gravitySource.Radius + gravitySource.transform.position;
        RotationFix();
        if (isFloating){
            transform.Rotate(new Vector3(0, 0, floatDirection));
            Float();
        }
    }

    void RotationFix(){
        //Vector3 targetDir = gravity.magnitude > float.Epsilon ? -gravity : transform.up;
        if (gravity.magnitude > float.Epsilon){
            Quaternion targetRot = Quaternion.FromToRotation(transform.up, -gravity) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 50 * Time.deltaTime);
        }else{
            transform.Rotate(Vector3.forward, floatingSpeed * Time.deltaTime);
        }
    }

    public void SetRotateDirection(float dir){
        if (System.Math.Abs(dir) < float.Epsilon) {
            return;
        }

        floatDirection = dir > 0 ? -1 : 1;
    }

    public Vector3 GetGravity(){
        return gravitySource != null
            ? (gravitySource.transform.position - transform.position).normalized * gravitySource.Power
            : Vector3.zero;
    }

    //public void GetCurrentOffset(){
    //    currentAngle = gravitySource != null ? (transform.position.x - gravitySource.transform.position.x) / (transform.position.y - gravitySource.transform.position.y) : 0f;
    //}

    //public void SetCurrentOffset(){
    //    if (gravitySource != null){
    //        float z = transform.position.z;
    //        Vector2 pos = new Vector2(currentAngle, 1f).normalized * (gravitySource.Radius);
    //        transform.position = new Vector3(gravitySource.transform.position.x + pos.x, gravitySource.transform.position.y + pos.y, transform.position.z);
    //    }
    //}

    //public void SyncPos(){
    //    currentAngle = (transform.position.x - gravitySource.transform.position.x) / (transform.position.y - gravitySource.transform.position.y);
    //}

    public void UseGravity(GravitySource source){
        if (source != null){
            gravitySource = source;
            transform.parent = source.transform.parent;
            //Float();
            isFloating = false;
        }
    }

    public void ResetGravity(){
        //gravitySource = GalaxyManager.Galaxy;
        transform.parent = transform.parent.parent;
        gravitySource = null;
        isFloating = true;
        //Float();
    }

    public void Float(){
        if (myRig.velocity.magnitude > floatingSpeed)
            myRig.velocity *= 0.95f;
    }

    public GravitySource GetGravitySource(){
        return gravitySource;
    }

    public void Orbit(float movement, float speed, float radius = 0){
        if (gravitySource != null){
            if (System.Math.Abs(radius) < float.Epsilon) {
                radius = gravitySource.Radius;
            }
            float angle = movement * speed * 180 / (Mathf.PI * radius);
            transform.RotateAround(gravitySource.transform.position, -Vector3.forward, angle);
        }
        //myRig.AddForce(movement * transform.up * speed * 100);
    }
}
