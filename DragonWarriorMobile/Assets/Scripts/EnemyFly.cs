using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float minHeight, maxHeight;
    public LayerMask lm; // bunu yapma amacýmýz zemine atadýgýmýz layer'i buraya tanýmlýcaz ve raycast sadece zemini dikkate alcak.


    void Start()
    {
        rb.velocity = new Vector2(0, -speed);
    }


    void Update()
    {
        Physics2D.queriesStartInColliders = false; // kartalýn kendi hitbox(collider) hesaba almýyor.


        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, Vector2.down, 8, lm);

        if (hit != null)
        {
            if (hit.distance <= minHeight)
            {
                rb.velocity = new Vector2(0, speed);
            }
            else if (hit.distance >= maxHeight)
            {
                rb.velocity = new Vector2(0, -speed);
            }
        }
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().Hit();
        }
    }



}
