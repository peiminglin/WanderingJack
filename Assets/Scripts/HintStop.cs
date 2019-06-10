using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintStop : MonoBehaviour
{
    bool ifShow = false;
    GameObject content;

    private void Start() {
        content = transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        ifShow |= collision.tag.Equals("Player");
        content.SetActive(ifShow);
    }

    private void OnTriggerExit2D(Collider2D collision) {
        ifShow &= !collision.tag.Equals("Player");
        content.SetActive(ifShow);
    }
}
