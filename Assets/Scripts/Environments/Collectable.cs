﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player"){
            Player player = collision.gameObject.GetComponent<Player>();
            player.Collect();
            Destroy(this.gameObject);
        }
    }
}