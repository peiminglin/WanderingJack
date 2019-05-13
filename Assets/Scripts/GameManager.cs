using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] levelPrefabs;
    GameObject currentLevelObject;
    int currentLevel = 0;
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

    void Update(){
        if (Input.GetKeyDown(KeyCode.R)){
            Restart();
        }
    }
}
