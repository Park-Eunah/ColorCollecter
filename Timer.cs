using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    float countdown = 200;  //시간은 200초

    public Text timeText;

    public GameObject player;
    public GameObject startCount;

    void Update()
    {
        CountTime();
    }

    void CountTime()
    {
        countdown -= Time.deltaTime;
        timeText.text = "Time : " + (int)countdown;

        if ((int)countdown == 0)  //남은 시간이 0초가 되면 게임은 끝난다.
        {
            player.SendMessage("GameOver");
        }
    }
}
