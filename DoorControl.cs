using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    float open = 150f;
    float close = 0f;

    Quaternion turn = Quaternion.identity;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DoorOpen();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            DoorClose();
        }
    }

    void DoorOpen()
    {
        anim.SetBool("close", false);
        anim.SetBool("open", true);

    }

    void DoorClose()
    {
        anim.SetBool("open", false);
        anim.SetBool("close", true);
    }
}
