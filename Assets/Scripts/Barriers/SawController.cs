using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour
{
    void Update(){
        transform.Rotate(new Vector3(0, 0, 3f));
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Player"){
            collision.gameObject.GetComponent<Player>().Hurt();
        }
    }
}
