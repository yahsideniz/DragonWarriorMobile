using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{

    //Giri� ekran�ndaki seviyeler butonu i�in
    public void LevelsButton()
    {
        SceneManager.LoadScene(1);
    }
}
