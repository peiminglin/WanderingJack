using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    GameObject goal;
    [SerializeField]
    GameManager myGM;

    static bool goalReady;
    static bool toWin;
    static bool toRestart;

    void Update() {
        if (goalReady){
            ShowGoal();
            goalReady = false;
        }

        if (toWin){
            toWin = false;
        }

        if (toRestart){
            myGM.Restart();
            toRestart = false;
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
