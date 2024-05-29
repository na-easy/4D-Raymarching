using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;
    public GameObject PauseMenuCanvas;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }
    }

    public void Stop()
    {
        if (!paused)
        {
            PauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
            paused = true;
        }
    }

    public void Play()
    {
        if (paused)
        {
            PauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
            paused = false;
        }
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("StartScene");
    }
}
