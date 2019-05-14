using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public float playerHealth;
    private Player player;
    public Image healthBar;
    public GameObject gameOverMenuUI;
    bool isOver = false;
    LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerHealth = (float)player.health/3;
        healthBar.fillAmount = playerHealth;

        if (playerHealth == 0)
            isOver = true;

        if (isOver)
            gameOverMenuUI.SetActive(true);
        else
            gameOverMenuUI.SetActive(false);



    }
}
