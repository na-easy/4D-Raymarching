using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

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

    public void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}