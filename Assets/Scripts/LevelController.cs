using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance = null;

    int sceneIndex;
    int levelComplete;

    void Start()
    {
        if (instance == null) 
        { 
            instance = this; 
        }

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
    }

    public void isEndGame()
    {
        if (levelComplete == 4) 
        {
            Invoke("LoadStartScene", 0f);
        }
        else
        {   
            PlayerPrefs.SetInt("LevelComplete", sceneIndex);
            Invoke("Teleport", 0f);
        }
    }

    void Teleport()
    {
        Loading.SwitchToScene(sceneIndex + 1);
    }

    void LoadStartScene()
    {
        Loading.SwitchToScene(0);
    }
}
