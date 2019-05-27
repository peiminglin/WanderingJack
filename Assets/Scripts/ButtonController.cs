using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    //public GameObject btn;
    //public GameObject position1, position2;
    public float startLerping;
    public float lerpTime;
    int shouldLerp =2;
    GameManager gm;
    public GameObject settingMenu;
    public GameObject levelMenu;
    public int currentLevel;
    public bool isLoad;
    public Text levelText;
    public bool isLoadNext;
    UIController uIController;
    public AudioClip playBGM, menuBGM;
    public AudioSource bgmPlayer;
    public AudioSource buttonSoundPlayer;

    private void Start()
    {
       // btn = GameObject.FindGameObjectWithTag("Btn");
        isLoad = false;
        isLoadNext = false;
        uIController = this.GetComponent<UIController>();
        levelMenu.SetActive(true);
        bgmPlayer.clip = menuBGM;
    }
    public void StartGame() {
        buttonSoundPlayer.Play();
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void RestartLevel(){
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gm.Restart();
    }

    public void BacktoMenu() {
        buttonSoundPlayer.Play();
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void OpenOption() {
        buttonSoundPlayer.Play();
        settingMenu.SetActive(true);
    }

    public void HideOption() {
        buttonSoundPlayer.Play();
        settingMenu.SetActive(false);
    }

    public void QuitGame() {
        buttonSoundPlayer.Play();
        Application.Quit();
    }
    public void LoadNextLevel() {
        buttonSoundPlayer.Play();
        currentLevel++;
        isLoadNext = true;
        levelText.text = "level - " + currentLevel;
        uIController.isWin = false;
    }
    public void LoadLevel(Button button)
    {
        buttonSoundPlayer.Play();
        currentLevel = int.Parse(button.GetComponentInChildren<Text>().text);
        levelMenu.SetActive(false);
        isLoad = true;
        levelText.text = "level - " + currentLevel;
        bgmPlayer.clip = playBGM;
        bgmPlayer.Play();
    }

    private void Update()
    {
        //if (shouldLerp == 1)
        //{
            //lerpTime = 0.5f;

            //float time = Time.time - startLerping;

            //float percentage = time / lerpTime;

            //btn.transform.position = Vector2.Lerp(position1.transform.position, position2.transform.position, percentage);


        //}
       // else if(shouldLerp ==0)
        //{
           // lerpTime = 0.5f;

            //float time = Time.time - startLerping;

           // float percentage = time / lerpTime;

           // btn.transform.position = Vector2.Lerp(position2.transform.position, position1.transform.position, percentage);

        //}

        
    }
    //public void MoveMenu() {
      //  startLerping = Time.time;
        //shouldLerp = 1;
        //
    //}

    //public void BacktoStart() {
      //  startLerping = Time.time;
        //shouldLerp = 0;

    //}
    
   
}
