using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thinking : MonoBehaviour
{
    public void Next(){
        transform.GetChild(0).GetComponent<ThinkingItem>().Next();
    }
}
