using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void buttonNextLevel()
    {
        //SceneManager.LoadScene(2);
        //ScoreGenerator.CoinCount_int = 0;

        LevelsManager.level2 = true;
        SceneManager.LoadScene("Levels");
        ScoreGenerator.CoinCount_int = 0;
    }

    public void buttonNextLevel2()
    {
        //SceneManager.LoadScene(3);
        //ScoreGenerator.CoinCount_int = 0;

        LevelsManager.level3 = true;
        SceneManager.LoadScene("Levels");
        ScoreGenerator.CoinCount_int = 0;
    }
}
