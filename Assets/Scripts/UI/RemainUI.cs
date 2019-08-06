using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RemainUI : MonoBehaviour
{
    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
        StartCoroutine(CheckRemain());
    }

    IEnumerator CheckRemain()
    {
        var sm = StageManager.Instance;
        while (true)
        {
            var count = sm._homes.Count((x) => { return !x.GetComponent<Home>()._isDone; });
            string str = String.Format("현재 남은 격문 : {0}", count);
            _text.text = str;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
