using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    UIController uiController;
    // Start is called before the first frame update
    void Awake()
    {
        uiController = GameObject.FindGameObjectWithTag("UI").GetComponent<UIController>();
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player"){
            LevelManager.Win();
            uiController.isWin = true;
            gameObject.SetActive(false);
        }
    }
}
