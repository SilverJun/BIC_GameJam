﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("User"))
        {
            StageManager.Instance.OnGameSuccess();
        }
    }
}
