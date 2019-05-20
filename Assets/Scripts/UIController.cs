using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private Player player;
    public GameObject first, second, third, forth, fifth;
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
print(player.Health);
            if (player.Health >= 1)
                first.SetActive(true);
            else
                first.SetActive(false);
            if (player.Health >= 2)
                second.SetActive(true);
            else
                second.SetActive(false);
            if (player.Health >= 3)
                third.SetActive(true);
            else
                third.SetActive(false);
            if (player.Health >= 4)
                forth.SetActive(true);
            else
                forth.SetActive(false);
            if (player.Health >= 5)
                fifth.SetActive(true);
            else
                fifth.SetActive(false);

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
