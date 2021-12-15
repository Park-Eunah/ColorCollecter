using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject gameManager;

    void Update()
    {
        gameManager.SendMessage("Menu");
    }
}
