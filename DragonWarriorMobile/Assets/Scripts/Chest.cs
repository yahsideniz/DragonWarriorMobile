using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    public float healt;

    public GameObject effect;
    public GameObject coin;

    public Animator anim;
   

    void Start()
    {
       
    }

    void Update()
    {
        if (healt <= 0)
        {
            anim.SetBool("isBroken", true);
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
            Instantiate(coin, transform.position, Quaternion.identity);
        }
        else
        {
            anim.SetBool("isBroken", false);

        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerHorn"))
        {
            healt -= 50;
        }

        if (collision.gameObject.tag == "PlayerFoot")
        {
            healt -= 50;
        }

        if (collision.gameObject.tag == "FireBall")
        {
            healt -= 100;
        }
    }

}
