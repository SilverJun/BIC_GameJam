using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartStage : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Stage" + PlayerPrefs.GetInt("CurStage"));
    }
}
