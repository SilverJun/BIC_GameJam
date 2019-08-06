using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Home : MonoBehaviour
{
    public bool _isDone = false;
    private ParticleSystem _ps;
    [SerializeField] private ParticleSystem _donePs;

    void Start()
    {
        _ps = GetComponent<ParticleSystem>();
        _donePs = transform.Find("DoneParticle").GetComponent<ParticleSystem>();
        _donePs.Stop();
        _isDone = false;
    }

    public void TurnOff()
    {
        StartCoroutine(turnOff());
    }

    IEnumerator turnOff()
    {
        _ps.Stop();
        GetComponent<SpriteRenderer>().DOFade(0,1.0f);
        
        _donePs.Play();
        yield return new WaitForSeconds(1.0f);
    }
}
