using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public GameObject gameManager;

    void Update()
    {
        GetSpace();
    }

    void GetSpace()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene == SceneManager.GetSceneByName("StartScreen") || scene == SceneManager.GetSceneByName("Tutorial"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameManager.SendMessage("LoadNextScene");
            }
        }
    }
}
