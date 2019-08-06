using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoticeHome : MonoBehaviour
{
    [SerializeField] private Home _home;
    private ParticleSystem _ps;

    // Start is called before the first frame update
    void Start()
    {
        _ps = _home.GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Color alpha = _ps.startColor;
        alpha.a = 1.0f;
        _ps.startColor = alpha;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Color alpha = _ps.startColor;
        alpha.a = 0.0f;
        _ps.startColor = alpha;
    }
}
