using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pasueMenuUI;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume() {
        pasueMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
        
    }

    void Pause() {
        pasueMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

    }

}
