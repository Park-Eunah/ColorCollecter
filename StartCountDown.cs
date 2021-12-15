using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartCountDown : MonoBehaviour
{

    float time = 0;

    public GameObject timeTxt;

    public Text countText;

    void Update()
    {
        CountDown();
    }

    void CountDown()
    {
        time += Time.deltaTime;

        if (time >= 0f && time <1f)
        {
            Scene scene = SceneManager.GetActiveScene();
            if(scene == SceneManager.GetSceneByName("Stage1"))
            {
                countText.text = "Stage 1";
            }
            else if (scene == SceneManager.GetSceneByName("Stage2"))
            {
                countText.text = "Stage 2";
            }
        }
        else if (time >= 1f && time < 2f)
        {
            countText.text = "3";
        }
        else if (time >= 2f && time < 3f)
        {
            countText.text = "2";
        }
        else if (time >= 3f && time < 4f)
        {
            countText.text = "1";
        }
        else if (time >= 4f && time < 5f)
        {
            countText.text = "Start!";
        }
        else if (time >= 5f)
        {
            timeTxt.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
