using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaFrog : MonoBehaviour
{

    public float healt;

    public GameObject effect;
    public GameObject coin;

    public AudioClip DeadClip;


    public Vector2 pos;
   
  

    public float distance;

    private Transform target;
    public float followspeed;


    private Animator anim;

    


    void Start()
    {
        Physics2D.queriesStartInColliders = false;

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();

        

    }

    void Update()
    {
        EnemyAi();


        if (healt <= 0)
        {
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
            Instantiate(coin, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(DeadClip, transform.position);
        }


        

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            healt -= 50;

        }

        if (collision.gameObject.tag == "PlayerFoot")
        {
            healt -= 100;
        }

        if (collision.gameObject.tag == "FireBall")
        {
            healt -= 100;
        }
    }



    void EnemyAi()
    {
        RaycastHit2D hitEnemy = Physics2D.Raycast(transform.position, -transform.right, distance);

        if (hitEnemy.collider != null)
        {
            Debug.DrawLine(transform.position, hitEnemy.point, Color.red);
            anim.SetBool("Attack", true);
            EnemyFollow();


        }
        else
        {
            Debug.DrawLine(transform.position, transform.position - transform.right * distance, Color.green);
            anim.SetBool("Attack", false);
            transform.position = pos;
            transform.position = Vector3.Lerp(pos, pos, Mathf.PingPong(Time.time * 1, 1.0f));

        }



    }

    void EnemyFollow()
    {
        Vector3 targetPosition = new Vector3(target.position.x, gameObject.transform.position.y, target.position.x);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, followspeed * Time.deltaTime);
    }


}
