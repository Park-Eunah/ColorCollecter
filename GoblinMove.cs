using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GoblinMove : MonoBehaviour
{
    float startTime = 0;

    bool isAlive = true;

    NavMeshAgent nvAgent;
    Animator anim;

    public GameObject player;
    public GameObject particle;

    public Image hpbar;
    public Image hpbar_Player;

    void Start()
    {
        nvAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        startTime += Time.deltaTime;

        if (startTime >= 5f)
        {
            float dist = Vector3.Distance(player.transform.position, transform.position);

            if (hpbar_Player.fillAmount <= 0.0f)
            {
                GameOver();
            }
            else
            {
                if (dist < 30)
                {
                    Move();

                    if (dist <= 5)
                    {
                        Attack();
                    }
                }
                else
                {
                    anim.SetBool("isMove", false);
                    nvAgent.velocity = Vector3.zero;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet_P")
        {
            particle.SendMessage("PlayParticle");
            hpbar.fillAmount -= 0.15f;

            if (hpbar.fillAmount <= 0f)
            {
                Die();
            }
        }
    }

    void GameOver()
    {
        nvAgent.enabled = false;
        anim.SetBool("isAttack", false);
        anim.SetBool("isMove", false);
    }

    void Move()
    {
        if (isAlive)
        {
            anim.SetBool("isMove", true);
            anim.SetBool("isAttack", false);
            transform.LookAt(player.transform);
            nvAgent.destination = player.transform.position;
        }
    }

    void Attack()
    {
        if (isAlive)
        {
            anim.SetBool("isMove", false);
            anim.SetBool("isAttack", true);
            transform.LookAt(player.transform);
        }
    }

    void Die()
    {
        GameOver();
        anim.SetBool("isDead", true);
        nvAgent.enabled = false;
        isAlive = false;
    }

    void Damage_P()
    {
        player.GetComponent<CharacterController>().Damage_Goblin();
    }
}
