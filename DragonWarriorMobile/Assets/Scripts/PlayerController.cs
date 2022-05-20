using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    private float hor;
    public Rigidbody2D rb;
    public float speed;

    public float jumpSpeed;

    public Animator anim;

    public int life;
    public Text lifeText;
    public float damagedTime;
    public Color normalColor;
    public Color damagedColor;

    public bool attack;
    public float attackTimer; // kaç saniye saldýrý yapabiliriz onun icin
    public float attackCoolDown;

    public CapsuleCollider2D attackCol;

    public int fireBallCount;
    public Text fireBallText; // Canvas olaylarý için.
    public Transform bulletSpawnPos; // yukardaki dedigimiz spawn objesini buraya atýcaz.
    public GameObject leftBullet, rightBullet;
    public bool isLookingRight; // bunu git saga sola baktýgýmýz kodda sag ise true sol ise false yap
    public bool FireBallCheck;

    public bool flyKick;
    BoxCollider2D flyKickCollider;

    public AudioSource AudioSource;

   

    LevelName levelName;
    public GameObject lvl;

    void Start()
    {

        life = 3;
        lifeText.text = life.ToString();// canvasa caný yazdýrýyoruz.
        normalColor = gameObject.GetComponent<SpriteRenderer>().color;
        attack = false; // ilk atak(kafa atma) için

        isLookingRight = true; //ateþtopu için
        fireBallText.text = fireBallCount.ToString(); // ateþtopunun kaç tane old. yazýsý için
        FireBallCheck = false; // ateþ topu için

        flyKickCollider = gameObject.transform.Find("Foot").GetComponent<BoxCollider2D>(); // uçan tekme için collider kullanýyoruz
        flyKick = false; // uçan tekme için


        //Koda eriþme level için
        levelName = lvl.GetComponent<LevelName>();
    }


    void Update()
    {
        //Ziplama
        //if (Input.GetKeyDown(KeyCode.Space) && gameObject.transform.Find("Foot").GetComponent<GroundCheck>().isGrounded)
        //{
        //    rb.AddForce(new Vector2(0, jumpSpeed));
        //}

       

        //üst üste damage almasýn diye ve renk deðiþsin damage alinca
        if (damagedTime > 0)
        {
            damagedTime -= Time.deltaTime;

            if (gameObject.GetComponent<SpriteRenderer>().color == normalColor)
            {
                gameObject.GetComponent<SpriteRenderer>().color = damagedColor;
            }
        }
        else
        {
            if (gameObject.GetComponent<SpriteRenderer>().color == damagedColor)
            {
                gameObject.GetComponent<SpriteRenderer>().color = normalColor;
            }
        }
        //---------------------------------------------------------------

        //Hurn Attack


        //if (Input.GetKeyDown(KeyCode.X) && !attack)
        //{
        //    attack = true;
        //    attackTimer = attackCoolDown;
        //}

        //if (attack)
        //{
        //    attackCol.enabled = true;

        //    if (attackTimer > 0)
        //    {
        //       attackTimer -= Time.deltaTime;
        //    }
        //    else
        //    {
        //        attack = false;
        //        attackCol.enabled = false;
        //    }
        //}
        HornAttack(0);



        //-----------------------------------------------------------------------


        // Fire Ball Attack

        //if (Input.GetKeyDown(KeyCode.LeftControl) && !FireBallCheck)
        //{
        //    FireBallCheck = true;
        //    attackTimer = attackCoolDown;
        //    Shoot();
        //}
        //if (FireBallCheck)
        //{
        //    AudioSource.Play();

        //    if (attackTimer > 0)
        //    {
        //        attackTimer -= Time.deltaTime;
        //    }
        //    else
        //    {
        //        FireBallCheck = false;
                
        //    }
        //}

        FireBallAttack(0);


        //-------------------------------------------------------------

        //Attack  FlyKick


        //if (Input.GetKeyDown(KeyCode.C) && !flyKick)
        //{
        //    flyKick = true;
        //    attackTimer = attackCoolDown;
        //}

        //if (flyKick)
        //{
            

        //    if (attackTimer > 0)
        //    {
        //        attackTimer -= Time.deltaTime;
        //    }
        //    else
        //    {
        //        flyKick = false;
               
        //    }
        //}


        FlyKickAttack(0);

    //---------------------------------------------------------


        //Anim
        anim.SetFloat("Speed", Mathf.Abs(hor));
        anim.SetBool("isGround", gameObject.transform.Find("Foot").GetComponent<GroundCheck>().isGrounded);
        anim.SetBool("Attack1", attack);
        anim.SetBool("FireBall", FireBallCheck);
        anim.SetBool("FlyKick", flyKick);

    }

    private void FixedUpdate()
    {
        // Hareket Kodu
        //hor = Input.GetAxis("Horizontal"); // a-d tuslari aktif
        rb.velocity = new Vector2(hor * speed * 100 * Time.deltaTime, rb.velocity.y); 

        //Kafayý cevirme
        if (hor > 0.1f) 
        {
            gameObject.transform.localScale = new Vector3(Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y, 0);
            isLookingRight = true;
        }


        if (hor < -0.1f) 
        {
            gameObject.transform.localScale = new Vector3(-Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y, 0);
            isLookingRight = false;
        }



    }

    // Butonlar için Haraket ve Skill Kodlarý

    public void Left()
    {
        hor = -1;
    }

    public void Right()
    {
        hor = 1;
    }

    public void Stop()
    {
        hor = 0;
    }

    public void Jump()
    {
        if (gameObject.transform.Find("Foot").GetComponent<GroundCheck>().isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpSpeed));
        }
    }

    public void HornAttack(int x)
    {

        if (x == 1 && !attack)
        {
            attack = true;
            attackTimer = attackCoolDown;
        }

        if (attack)
        {
            attackCol.enabled = true;

            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attack = false;
                attackCol.enabled = false;
            }
        }


    }

    public void FireBallAttack(int y)
    {
        if (y==1 && !FireBallCheck)
        {
            FireBallCheck = true;
            attackTimer = attackCoolDown;
            Shoot();
        }
        if (FireBallCheck)
        {
            AudioSource.Play();

            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                FireBallCheck = false;

            }
        }
    }

    public void FlyKickAttack(int z)
    {
        if (z==1 && !flyKick)
        {
            flyKick = true;
            attackTimer = attackCoolDown;
        }

        if (flyKick)
        {


            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                flyKick = false;

            }
        }

    }

    //----------------------------------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Heart" && life < 3)
        {
            life++;
            lifeText.text = life.ToString();
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && damagedTime <= 0)
        {
            Hit();

        }
        if (collision.gameObject.tag == "Trampoline")
        {

            rb.AddForce(new Vector2(0, 1200));
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && damagedTime <= 0)
        {
            Hit();

        }
    }

    public void Hit()
    {
        life--;
        lifeText.text = life.ToString();
        damagedTime = 0.7f;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.6f, gameObject.transform.position.z);

        if (life <= 0)
        {
            SceneManager.LoadScene(levelName.indexLevel);
            ScoreGenerator.CoinCount_int = 0;
        }
    }


    private void Shoot()
    {
        if (fireBallCount > 0)
        {
            if (isLookingRight)
            {
                Instantiate(rightBullet, bulletSpawnPos.position, Quaternion.identity);
            }
            else
            {
                Instantiate(leftBullet, bulletSpawnPos.position, Quaternion.identity);
            }
            fireBallCount--;
            fireBallText.text = fireBallCount.ToString();
        }
    }
}
