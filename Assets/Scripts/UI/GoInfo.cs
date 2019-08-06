using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoInfo : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Info");
    }
}
