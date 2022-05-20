using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{

    //Giriþ ekranýndaki seviyeler butonu için
    public void LevelsButton()
    {
        SceneManager.LoadScene(1);
    }
}
