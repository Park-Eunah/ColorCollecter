using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckStage : MonoBehaviour
{
    public static int stage = 0;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        Check();
    }

    void Check()
    {
        Scene scene = SceneManager.GetActiveScene();

        if(scene == SceneManager.GetSceneByName("Stage1"))
        {
            stage = 1;
        }
        else if(scene == SceneManager.GetSceneByName("Stage2"))
        {
            stage = 2;
        }
        else if(scene == SceneManager.GetSceneByName("Stage3"))
        {
            stage = 3;
        }
        else if(scene == SceneManager.GetSceneByName("StartScreen"))
        {
            stage = 0;
        }
    }
}
