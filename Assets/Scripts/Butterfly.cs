using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour
{
    Transform target;
    Animator animator;
    Material mat;
    Vector2 lastPos;
    Vector2 newPos;
    readonly float speed = 1f;
    float timer;

    // Start is called before the first frame update
    void Start(){
        animator = GetComponent<Animator>();
        mat = GetComponent<Renderer>().material;
        mat.color = Random.ColorHSV(0, 1, 0.1f, 0.5f, 0.8f, 1f, 1f, 1f);
        lastPos = transform.position;
        newPos = lastPos;
        animator.SetBool("IsFly", true);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * speed;
        timer = timer > 1 ? 1 : timer;

        float dist = Vector2.Distance(transform.position.To2d(), newPos);
        if (dist < 0.001f) {
            lastPos = newPos;
            Vector2 offset = target == null ? Random.insideUnitCircle : (target.position.To2d() - lastPos).normalized.Rotate(Random.Range(-60f, 60f));
            newPos = offset + lastPos;
            timer = 0;
        } else {
            transform.position = Vector2.Lerp(lastPos, newPos, timer).To3d();
        }

        transform.rotation = Quaternion.FromToRotation(transform.up, transform.position - transform.parent.position) * transform.rotation;
    }

    void ResetTarget(Transform sth = null){
        target = sth;
    }
}
