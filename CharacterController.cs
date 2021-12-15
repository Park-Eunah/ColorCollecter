using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    float speed = 5;
    float jumpPower = 2;
    float x, z, r;
    float time = 0;

    Transform tr;
    Animator anim;
    Rigidbody rig;

    public GameObject stageClear;
    public GameObject bullet;
    public GameObject timeText;
    public GameObject hpbar;
    public GameObject gameManager;
    public GameObject particle;

    public Transform firePosition;

    public Text hpText;

    private bool isJumping;   //점프 중인지 확인

    void Start()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
        isJumping = false;
    }

    void Update()
    {
       time += Time.deltaTime;
       if(time >= 5f)
        {
            timeText.SetActive(true);
            hpbar.SetActive(true);

            Move();
            SetAnimation();
            Attack();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")     //캐릭터가 땅과 충돌하면 점프 가능한 상태로 변경
        {
            isJumping = false;
        }
        else if(collision.collider.tag == "Bullet_A")
        {
            particle.SendMessage("PlayParticle");
            hpbar.GetComponent<Image>().fillAmount -= 0.2f;
            hpText.text = (int)(hpbar.GetComponent<Image>().fillAmount * 100) + 1 + " / 100";

            if (hpbar.GetComponent<Image>().fillAmount <= 0.0f)  //피가 다 깎이면 게임은 끝난다.
            {
                GameOver();
                hpText.text = "0 / 100"; ;
            }
        }
    }

    void Jump()
    {
        if (!isJumping)   //점프중이 아니라면 점프 가능
        {
            rig.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJumping = true;  //점프중으로 상태 변경
        }
        else  //점프중이라면 리턴
        {
            return;
        }
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))  //마우스 좌클릭하면 공격
        {
            anim.CrossFade("Attack01", 0.5f);
            Object obj = Instantiate(bullet, firePosition.position, firePosition.rotation);
            Destroy(obj, 2.0f);
        }
        else
        {
            if (hpbar.GetComponent<Image>().fillAmount <= 0.0f)  //피가 다 깎이면 게임은 끝난다.
            {
                GameOver();
                hpText.text = "0 / 100"; ;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ColorBall")
        {
            StageClear();
        }
    }

    void GameOver()
    {
        speed = 0;
        gameManager.SendMessage("GameOver");
    }

    void SetAnimation()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))   //앞으로 이동 애니메이션 활성화
        {
            anim.SetBool("isRunF", true);
            anim.SetBool("isRunB", false);
            anim.SetBool("isRunR", false);
            anim.SetBool("isRunL", false);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))  //뒤로 이동 애니메이션 활성화
        {
            anim.SetBool("isRunB", true);
            anim.SetBool("isRunF", false);
            anim.SetBool("isRunR", false);
            anim.SetBool("isRunL", false);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("isRunR", true);
            anim.SetBool("isRunF", false);
            anim.SetBool("isRunB", false);
            anim.SetBool("isRunL", false);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("isRunL", true);
            anim.SetBool("isRunF", false);
            anim.SetBool("isRunB", false);
            anim.SetBool("isRunR", false);
        }
        else  //이동 안하면 애니메이션 비활
        {
            anim.SetBool("isRunF", false);
            anim.SetBool("isRunB", false);
            anim.SetBool("isRunR", false);
            anim.SetBool("isRunL", false);
        }
    }

    void Move()
    {
        x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;  
        z = Input.GetAxis("Vertical") * Time.deltaTime * speed;  
        r = Input.GetAxis("Mouse X") * 2;   

        tr.Translate(x, 0, z);
        tr.Rotate(0, r, 0);

        if (Input.GetKeyDown(KeyCode.Space))   //스페이스바 누르면 점프
        {
            Jump();
        }
    }

    public  void Damage_Goblin()
    {
        particle.SendMessage("PlayParticle");
        hpbar.GetComponent<Image>().fillAmount -= 0.1f;
        hpText.text = (int)(hpbar.GetComponent<Image>().fillAmount * 100) + 1 + " / 100";

        if (hpbar.GetComponent<Image>().fillAmount <= 0.0f)  //피가 다 깎이면 게임은 끝난다.
        {
            GameOver();
            hpText.text = "0 / 100"; ;
        }
    }

    void StageClear()
    {
        stageClear.SetActive(true);

        float time = 0;
        time += Time.deltaTime;
        if(time >= 1.5f)
        {
            gameManager.SendMessage("LoadNextScene");
        }
    }
}


