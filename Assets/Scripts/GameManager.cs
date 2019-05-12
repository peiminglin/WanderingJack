using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] levelPrefabs;
    int currentLevel = 0;
    public static Player player;

    void Start(){
        if (levelPrefabs.Length > currentLevel)
            Instantiate(levelPrefabs[currentLevel], Vector3.zero, Quaternion.identity);
    }

    void Update(){
        
    }
}
