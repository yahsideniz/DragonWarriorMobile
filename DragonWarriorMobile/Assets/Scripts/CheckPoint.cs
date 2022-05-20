using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Animator anim;
    public bool Touched;


    private void Start()
    {
        Touched = false;
    }
    private void Update()
    {
        anim.SetBool("isFinish", Touched);
    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && ScoreGenerator.CoinCount_int >= 10)
        {
            Touched = true;
        }
        else
        {
            Touched = false;
        }
    }


}
