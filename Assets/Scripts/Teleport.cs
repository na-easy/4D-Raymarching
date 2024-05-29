using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{

    void OnTriggerEnter(Collider collider)
    {
        Loading.SwitchToScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
