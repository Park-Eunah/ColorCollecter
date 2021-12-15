using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool isMenu = false;

    public GameObject gameOver;
    public GameObject menuPanel;

    public static GameManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
        Time.timeScale = 0;
    }

    void LoadNextScene() 
    {
        Scene scene = SceneManager.GetActiveScene();
        int curScene = scene.buildIndex;
        int nextScene = curScene + 1;
        SceneManager.LoadScene(nextScene);
    }

    void Menu()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene == SceneManager.GetSceneByName("Stage1") || scene == SceneManager.GetSceneByName("Stage2") || scene == SceneManager.GetSceneByName("Stage3"))
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!isMenu)
                {
                    isMenu = true;
                    Time.timeScale = 0;
                    menuPanel.SetActive(true);
                }
                else
                {
                    isMenu = false;
                    Time.timeScale = 1;
                    menuPanel.SetActive(false);
                }
            }
        }
    }

    public void Restart()  
    {
        if(CheckStage.stage == 1)
        {
            SceneManager.LoadScene("Stage1");
        }
        else if(CheckStage.stage == 2)
        {
            SceneManager.LoadScene("Stage2");
        }
        else if(CheckStage.stage == 3)
        {
            SceneManager.LoadScene("Stage3");
        }
        Time.timeScale = 1;
    }

    public void GotoMain()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void Quit() 
    {
        Application.Quit();
    }
}