using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorBallController : MonoBehaviour
{
    Collider collider;

    public Image[] GoblinHps;

    void Start()
    {
        collider = GetComponent<Collider>();
        collider.enabled = false;
    }

    void Update()
    {
        CheckGoblins();
    }

    void CheckGoblins()
    {
        for(int i =0; i < GoblinHps.Length; i++)
        {
            if(GoblinHps[i].fillAmount <= 0f)
            {
                if(GoblinHps[i] == GoblinHps[GoblinHps.Length - 1])
                {
                    SetCollider();
                }
                else
                {
                    continue;
                }
            }
            else
            {
                break;
            }
        }
    }
    void SetCollider()
    {
        collider.enabled = true;
    }
}
