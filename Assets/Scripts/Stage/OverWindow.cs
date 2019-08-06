using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Assertions;

public class OverWindow : MonoBehaviour
{
    private bool _isDone = false;
    private AudioSource _audio;

    public void Show()
    {
        _audio = GetComponent<AudioSource>();
        transform.position += (Vector3.up*13);
        Assert.IsTrue(gameObject.activeSelf);
        Debug.Log(transform.position);
    }

    void Update()
    {
        if (transform.position.y >= Camera.main.gameObject.transform.position.y)
        {
            transform.position -= new Vector3(0.0f, 0.3f, 0.0f);
            _isDone = true;
        }
        else if (_isDone)
        {
            lastAction();
            _isDone = false;
        }
    }

    void lastAction()
    {
        _audio.Play();
        Camera.main.DOShakePosition(0.2f, 1.0f).SetUpdate(true);
    }
}
