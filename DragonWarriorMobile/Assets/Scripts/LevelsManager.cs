using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour
{
    public Button level1_button, level2_button, level3_button;
    public static bool level1, level2, level3;

    private void Start()
    {
        level1 = true;
    }

    private void Update()
    {
        if(level2==true)
        {
            level2_button.interactable = true;
        }

        if (level3 == true)
        {
            level3_button.interactable = true;
        }
    }

    public void level1Button()
    {
        SceneManager.LoadScene(2);

    }

    public void level2Button()
    {
        SceneManager.LoadScene(3);

    }
    public void level3Button()
    {
        SceneManager.LoadScene(4);

    }

    
}
