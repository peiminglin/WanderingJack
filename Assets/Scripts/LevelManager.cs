using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    GameObject goal;

    GameManager myGM;

    static bool goalReady;
    static bool toWin;
    static bool toRestart;

    private void Start() {
        myGM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update() {
        if (goalReady){
            ShowGoal();
            goalReady = false;
        }

        if (toWin){
            toWin = false;
            myGM.Restart();
        }

        if (toRestart){
            toRestart = false;
            myGM.Restart();
        }
    }

    public void ShowGoal(){
        goal.SetActive(true);
    }

    public static void GoalReached(){
        goalReady = true;
    }

    public static void Win(){
        toWin = true;
    }

    public static void Restart(){
        toRestart = true;
        goalReady = false;
        toWin = false;
    }
}
