using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour


{

    Animator anim;
    AudioSource pickupSound;
    private void Start()
    {
        pickupSound = GameObject.FindGameObjectWithTag("PickupSound").GetComponent<AudioSource>();
        anim = GameObject.FindGameObjectWithTag("MissionBar").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player"){
            Player player = collision.gameObject.GetComponent<Player>();
            anim.SetTrigger("isCollected");
            player.Collect();
            Destroy(this.gameObject);
            pickupSound.Play();
        }
    }
}
