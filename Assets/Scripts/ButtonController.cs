using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject btn;
    public GameObject position1, position2;
    public float startLerping;
    public float lerpTime;
    int shouldLerp =2;

    private void Start()
    {
        btn = GameObject.FindGameObjectWithTag("Btn");
    }
    public void StartGame() {
        SceneManager.LoadScene(1);
    }
    public void BacktoMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        Application.Quit();
    }
    private void Update()
    {
        if (shouldLerp == 1)
        {
            lerpTime = 1.0f;

            float time = Time.time - startLerping;

            float percentage = time / lerpTime;

            btn.transform.position = Vector2.Lerp(position1.transform.position, position2.transform.position, percentage);


        }
        else if(shouldLerp ==0)
        {
            lerpTime = 1.0f;

            float time = Time.time - startLerping;

            float percentage = time / lerpTime;

            btn.transform.position = Vector2.Lerp(position2.transform.position, position1.transform.position, percentage);

        }

        
    }
    public void MoveMenu() {
        startLerping = Time.time;
        shouldLerp = 1;

    }

    public void BacktoStart() {
        startLerping = Time.time;
        shouldLerp = 0;

    }
    
   
}
