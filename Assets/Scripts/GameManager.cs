using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] levelPrefabs;
    GameObject currentLevelObject;
    int currentLevel = 1;
    //public static Player player;

    void Start(){
        Restart();
    }

    public void StartLevel(int level){
        if (levelPrefabs.Length > level){
            currentLevelObject = Instantiate(levelPrefabs[level], Vector3.zero, Quaternion.identity);
        }
    }

    public void Restart(){
        if (currentLevelObject != null)
            Destroy(currentLevelObject);
        StartLevel(currentLevel);
    }

    public void Restart(float seconds){
        Invoke("Restart", seconds);
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.R)){
            Restart();
        }
    }
}
