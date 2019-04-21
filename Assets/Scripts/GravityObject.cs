using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityObject : MonoBehaviour {

    GravitySource gravitySource;
    Rigidbody2D myRig;
    Vector3 gravity;
    Vector3 bodyUp;
    bool isFloating;
    public bool IsFloating{ 
        get { return isFloating; } 
        set { isFloating = value; }
    }

    // Start is called before the first frame update
    void Start() {
        myRig = GetComponent<Rigidbody2D>();
        myRig.constraints = RigidbodyConstraints2D.FreezeRotation;
        myRig.gravityScale = 0f;
        gravity = new Vector3();
        bodyUp = transform.up;
    }

    // Update is called once per frame
    void Update() {
        gravity = GetGravity();
        myRig.AddForce(gravity);
        RotationFix();
    }

    void RotationFix(){
        Quaternion targetRot = Quaternion.FromToRotation(transform.up, -gravity) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 50 * Time.deltaTime);
    }

    public Vector3 GetGravity(){
        return (gravitySource.transform.position - transform.position).normalized * gravitySource.Power;
    }

    public void UseGravity(GravitySource source){
        gravitySource = source;
        isFloating = false;
    }

    public void ResetGravity(){
        gravitySource = GalaxyManager.Galaxy;
        isFloating = true;
    }

    public GravitySource GetGravitySource(){
        return gravitySource;
    }

    public void Orbit(float dir, float speed) {
        transform.RotateAround(gravitySource.transform.position, -Vector3.forward, dir * speed * 50f);
    }

    //public void AddGravity(GravitySource source){
    //    gravitySources.Add(source);
    //}

    //public void RemoveGravity(GravitySource source){
    //    gravitySources.Remove(source);
    //}
}
