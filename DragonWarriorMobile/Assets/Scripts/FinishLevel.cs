using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public GameObject panel;
    public GameObject Player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player" && ScoreGenerator.CoinCount_int>=10)
        {
            panel.SetActive(true);
            Player.SetActive(false);
        }
    }

    public void backToStart()
    {
        SceneManager.LoadScene(1);
        ScoreGenerator.CoinCount_int = 0;
    }
}
