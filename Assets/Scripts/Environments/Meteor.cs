using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    LineRenderer line;
    Vector2 start;
    Vector2 end;
    Vector2 head;
    Vector2 tail;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        timer = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 1.5f){
            timer = -1;
            line.enabled = false;
            Invoke("Respawn", Random.Range(10f, 25f));
        } else if (timer >= 0){
            timer += Time.deltaTime;
            head = Vector2.Lerp(start, end, timer > 1 ? 1 : timer);
            if (timer > 0.5f){
                tail = Vector2.Lerp(start, end, timer - 0.5f);
            }

            line.SetPosition(0, head);
            line.SetPosition(1, tail);
        }
    }

    void Respawn(){
        start = Random.insideUnitCircle.normalized * Random.Range(5f, 10f);
        end = Random.insideUnitCircle.normalized * 3f + Camera.main.transform.position.To2d();
        end = (end - start).normalized * 40 + start;
        head = start;
        tail = start;
        line.enabled = true;
        timer = 0;
    }
}
