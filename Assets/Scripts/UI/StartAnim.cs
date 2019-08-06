using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StartAnim : MonoBehaviour
{
    void Start()
    {
        Debug.Log("aaa");
        var spriteRenderer = GetComponent<SpriteRenderer>();
        Sequence seq = DOTween.Sequence();
        seq.Append(spriteRenderer.DOColor(Color.white, 2f));
        seq.Append(spriteRenderer.DOFade(0.0f, 1f));
        seq.Play();
    }
}
