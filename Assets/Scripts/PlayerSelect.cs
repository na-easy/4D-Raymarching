using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour
{
    [SerializeField]
    MaterialSO material;

    public void Red()
    {
        material.Value.SetColor("_Color", Color.red);
    }

    public void Green()
    {
        material.Value.SetColor("_Color", Color.green);
    }

    public void Blue()
    {
        material.Value.SetColor("_Color", Color.blue);
    }

    public void White()
    {
        material.Value.SetColor("_Color", Color.white);
    }
   
    public void Continue()
    {
        LevelController.instance.isEndGame();
    }
}
