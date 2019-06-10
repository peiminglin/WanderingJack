using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private Player player;
    public Image healthBar;
    public Image energyBar;
    public Image missionBar;
    public GameObject shipImgObj;

    public GameObject gameOverMenuUI;
    public bool isOver = false;
    public bool isWin;
    private LevelManager levelManager;
    public GameObject winMenuUI;
    public Button[] levelsBtns;
    public int unlockedLevel;

    // Start is called before the first frame update
    void Start()
    {
        Restart();
        //UnlockLevel();
    }

    public void Restart(){
        isWin = false;
        isOver = false;
        shipImgObj.SetActive(false);
        ResetMission();
    }

    // Update is called once per frame
    void Update()
    {
        UnlockLevel();
        if (player == null){
            GameObject go = GameObject.FindGameObjectWithTag("Player");
            if (go != null){
                player = go.GetComponent<Player>();
            }
        } else {
            healthBar.fillAmount = (float)player.Health / player.maxHealth;

            energyBar.fillAmount = (float)player.Energy / player.maxEnergy;

            if ((player.totalCollectable - player.collected) != 0)
            {
                missionBar.fillAmount = (float)(player.totalCollectable - player.collected) / player.totalCollectable;
            }
            else
            {
                missionBar.fillAmount = 1;
                shipImgObj.SetActive(true);
            }

            if (player.Health <= 0 &&!isWin)
                isOver = true;
            else
                isOver = false;

            if (isOver)
            {
                gameOverMenuUI.SetActive(true);
            }
            else
                gameOverMenuUI.SetActive(false);


            if (isWin)
            {
                winMenuUI.SetActive(true);
                Time.timeScale = 0;
            }
            else
                winMenuUI.SetActive(false);
        }
    }

    void UnlockLevel() {
        unlockedLevel = PlayerPrefs.GetInt("unlockedLevel") - 1;
        for (int i = 0; i < levelsBtns.Length; i++)
        {
            if (i > unlockedLevel)
                levelsBtns[i].interactable = false;
        }
    }

    public void ResetMission() {
        if (player != null)
            player.collected = 0;
        shipImgObj.SetActive(false);
    }

    public void Reset()
    {
       player.Health = player.maxHealth;
       player.Energy = player.maxEnergy;
        
    }
}
