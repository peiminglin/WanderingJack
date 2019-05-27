using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;

    public Transform[] move_spots;
    //private int random_spot;
    private int current;

    public float wait_time;
    private float countdown;

    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        //random_spot = Random.Range(0,move_spots.Length);
        countdown = wait_time;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, move_spots[current].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, move_spots[current].position) < 0.2f)
        {
            if (countdown <= 0)
            {
                countdown = wait_time;
                if (current == move_spots.Length - 1)
                    current = 0;
                else current += 1;
            }
            else countdown -= Time.deltaTime;
        }
    }
}
