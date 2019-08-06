using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("menu");
    }
}
