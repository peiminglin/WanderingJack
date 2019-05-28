using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : FlyEnemy
{
    //public float speed;

    public Transform[] move_spots;
    //private int random_spot;
    private int current_spot;
    private bool going_back;

    public float wait_time;
    private float countdown;

    // Start is called before the first frame update
    void Start()
    {
        current_spot = 5;
        //random_spot = Random.Range(0,move_spots.Length);
        countdown = wait_time;
        going_back = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, move_spots[current_spot].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, move_spots[current_spot].position) < 0.2f)
        {
            if (countdown <= 0)
            {
                countdown = wait_time;
                if (current_spot == move_spots.Length - 1)
                {
                    current_spot = 0;
                    going_back = true;
                }
                else if (going_back == false)
                {
                    current_spot += 1;
                }
                else if (going_back == true && current_spot != 0)
                {
                    current_spot -= 1;
                }
                else going_back = false;
            }
            else countdown -= Time.deltaTime;
        }
    }
}
