using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    public float speed;


    void Start()
    {
        Invoke("DestroyFireBall", 2.5f);
    }


    void Update()
    {
        gameObject.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            //Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.tag == "Floor")
        {
            Destroy(gameObject);
        }
        if (collision.tag == "Chest")
        {
            Destroy(gameObject);
        }
    }

    void DestroyFireBall()
    {
        Destroy(gameObject);
    }
}
