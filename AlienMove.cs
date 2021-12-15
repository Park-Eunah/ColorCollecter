using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienMove : MonoBehaviour
{
    float shootTime = 0;

    bool isAlive;

    public GameObject player;
    public GameObject alienBullet;

    public Transform firePos;

    public Image hp;

    Animator anim;

    void Start()
    {
        isAlive = true;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isAlive)
        {
            LookPlayer();
            Attack();
        }
    }

    void LookPlayer()
    {
        transform.LookAt(player.transform);
    }

    void Attack()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);

        if(dist <= 60)
        {
            shootTime += Time.deltaTime;

            if (shootTime >= 4.0f)
            {
                Debug.Log("attack");
                anim.SetBool("isAttack", true);
                GameObject bullet = Instantiate(alienBullet, firePos.position, firePos.rotation);
                Destroy(bullet, 2.5f);
                bullet.transform.LookAt(player.transform);
                shootTime = 0f;
            }
            else
                anim.SetBool("isAttack", false);
        }
        else
        {
            shootTime = 0f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Bullet_P")
        {
            anim.CrossFade("isDamage", 0.5f);
            hp.fillAmount -= 0.05f;
            if(hp.fillAmount <= 0f)
            {
                Die();
            }
        }

    }

    void Die()
    {
        anim.SetBool("isDead", true);
        isAlive = false;
    }
}
