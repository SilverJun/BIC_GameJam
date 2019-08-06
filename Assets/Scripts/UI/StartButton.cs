using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("Tuto", 1);
    }

    private void OnMouseDown()
    {
        if (PlayerPrefs.GetInt("Tuto", 0) == 0)
        {
            PlayerPrefs.SetInt("Tuto", 1);
            SceneManager.LoadScene("Tuto");
        }
        else
        {
            SceneManager.LoadScene("Stage1");
        }
    }
}
