﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinkingItem : MonoBehaviour
{
    [SerializeField]
    Sprite[] sprites;
    int currentGoal = 0;
    //SpriteRenderer spRenderer;

    void Update(){
        transform.Rotate(new Vector3(0, 0, 1f));
    }

    public void Next(){
        currentGoal = (currentGoal + 1) % sprites.Length;
        GetComponent<SpriteRenderer>().sprite = sprites[currentGoal];
    }

    public void Reset() {
        currentGoal = 0;
    }
}
