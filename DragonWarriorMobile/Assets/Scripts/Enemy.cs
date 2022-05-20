using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float healt;

    public GameObject effect;
    public GameObject coin;

    public AudioClip DeadClip;
    void Start()
    {
        
    }

    void Update()
    {
        if (healt <= 0)
        {
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
            Instantiate(coin, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(DeadClip,transform.position);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerHorn"))
        {
            healt -= 100;
            
        }

        if(collision.gameObject.tag=="PlayerFoot")
        {
            healt -= 100;
        }

        if(collision.gameObject.tag=="FireBall")
        {
            healt -= 100;
        }
    }

   
}
