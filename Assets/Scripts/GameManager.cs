using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] levelPrefabs;
    GameObject currentLevelObject;
    [SerializeField]
    int currentLevel = 1;
    //public static Player player;
    public ButtonController buttonController;
    public GameObject levelAnnouncer;

    void Start(){
        Time.timeScale = 0;
        levelAnnouncer.SetActive(true);
    }

    public void StartLevel(int level){
        if (currentLevelObject != null)
            Destroy(currentLevelObject);
        if (level < levelPrefabs.Length){
            currentLevelObject = Instantiate(levelPrefabs[level], Vector3.zero, Quaternion.identity);
        }
    }

    public void Restart(){
        StartLevel(buttonController.currentLevel-1);
    }

    public void Restart(float seconds){
        Invoke("Restart", seconds);
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.R)){
            Restart();
        }
        if (buttonController.isLoad)
        {
            if (Time.timeScale == 0)
            {
                ReloadLevel();
            }
            Time.timeScale = 1;
            buttonController.isLoad = false;
        }

        if (buttonController.isLoadNext) {
            ReloadLevel();
            levelAnnouncer.SetActive(true);
            
            buttonController.isLoadNext = false;
        }
            
    }

    void DisableAnnouncer() {
        levelAnnouncer.SetActive(false);
    }

    void ReloadLevel() {
        Invoke("DisableAnnouncer", 1);
        Restart(1.1f);
    }
}
