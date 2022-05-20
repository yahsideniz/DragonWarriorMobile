using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreGenerator : MonoBehaviour
{
    public Text CoinCount;
    public static int CoinCount_int=0;


    void Update()
    {
        CoinCount.text = CoinCount_int.ToString();

    }
}
