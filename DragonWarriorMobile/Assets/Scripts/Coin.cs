using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip coinClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            ScoreGenerator.CoinCount_int++;
            Destroy(this.gameObject);

            AudioSource.PlayClipAtPoint(coinClip, transform.position);
        }
    }
}
