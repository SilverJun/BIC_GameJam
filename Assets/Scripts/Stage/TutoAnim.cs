using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutoAnim : MonoBehaviour
{
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            SceneManager.LoadSceneAsync("Stage1");
        }
    }
}
