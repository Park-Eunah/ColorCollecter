using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        
    }

    void ChangeMusic()
    {
        Scene scene = SceneManager.GetActiveScene();

        if(scene == SceneManager.GetSceneByName("Stage1"))
        {
            Destroy(gameObject);
        }
    }
}
