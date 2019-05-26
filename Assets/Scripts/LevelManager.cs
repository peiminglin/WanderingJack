using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    GameObject goal;
    [SerializeField]
    HealthBar myHealthBar;

    GameManager myGM;
    public static Player player;

    static bool goalReady;
    static bool toWin;
    static bool toRestart;
    static bool toSetPlayer;

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
            myGM.Restart(2f);
        }

        if (toRestart){
            toRestart = false;
            //myGM.Restart(2f);
        }

        if (toSetPlayer){
            toSetPlayer = false;
            //myHealthBar.gameObject.SetActive(true);
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

    public static void SetPlayer(Player me){
        toSetPlayer = true;
        player = me;
    }
}
