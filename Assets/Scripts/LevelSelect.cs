using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public Button level1;
    public Button level2;
    public Button level3;
    public Button level4;
    int levelComplete;

    void Start()
    {
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        level1.interactable = false;
        level2.interactable = false;
        level3.interactable = false;
        level4.interactable = false;

        switch (levelComplete)
        {
            case 1:
                level1.interactable = true;
                break;
            case 2:
                level1.interactable = true;
                level2.interactable = true;
                break;
            case 3:
                level1.interactable = true;
                level2.interactable = true;
                level3.interactable = true;
                break;
            case 4:
                level1.interactable = true;
                level2.interactable = true;
                level3.interactable = true;
                level4.interactable = true;
                break;
        }
    }

    public void LoadTo(int level)
    {
        Loading.SwitchToScene(level);
    }

    public void ResetLevel()
    {
        level1.interactable = false;
        level2.interactable = false;
        level3.interactable = false;
        level4.interactable = false;
        PlayerPrefs.DeleteKey("LevelComplete");
    }
}
