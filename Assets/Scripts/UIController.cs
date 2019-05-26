using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private Player player;
    public Image healthBar;
    public GameObject gameOverMenuUI;
    bool isOver = false;
    public bool isWin;
    private LevelManager levelManager;
    public GameObject winMenuUI;
    

    // Start is called before the first frame update
    void Start()
    {
        isWin = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        if (go != null){
            player = go.GetComponent<Player>();

            healthBar.fillAmount = (float)player.Health / player.maxHealth;

            if (player.Health <= 0)
                isOver = true;
            
            if (isOver)
                gameOverMenuUI.SetActive(true);
            else
                gameOverMenuUI.SetActive(false);

            if (player.Health == 0)
                isOver = true;

            if (isWin)
                winMenuUI.SetActive(true);
            else
                winMenuUI.SetActive(false);
        }
    }
}
