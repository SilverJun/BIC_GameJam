using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoSingleton<StageManager>
{
    private GameObject _overWindow;
    [SerializeField] public List<GameObject> _homes;
    [SerializeField] private int _currentStageNum = 1;
    [SerializeField] private float _limitTime = 30.0f;

    void Start()
    {
        _overWindow = Instantiate(Resources.Load<GameObject>("Prefab/OverWindow"), Vector3.zero, Quaternion.identity);
        _overWindow.active = false;
        Time.timeScale = 1.0f;
    }

    public void OnGameSuccess()
    {
        var count = _homes.Count((x) => { return !x.GetComponent<Home>()._isDone; });
        Debug.Log(count);
        if (count != 0)
            return;

        Debug.Log("Game Success!");

        // 다음스테이지로.
        Instance._currentStageNum += 1;

        if (Instance._currentStageNum >= 4)
        {
            SceneManager.LoadScene("GameEnd");
        }
        else
            SceneManager.LoadScene("Stage" + Instance._currentStageNum);
    }

    public void OnGameFailure()
    {
        Debug.Log("Game Failure!");
        /// 철컹 애니메이션 추가
        Time.timeScale = 0.0f;

        PlayerPrefs.SetInt("CurStage", _currentStageNum);

        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        var player = GameObject.FindGameObjectWithTag("User");
        _overWindow.transform.position = player.transform.position; 
        _overWindow.SetActive(true);
        _overWindow.GetComponent<OverWindow>().Show();
        yield return new WaitForSecondsRealtime(4f);
        SceneManager.LoadScene("Retry");
        Time.timeScale = 1.0f;
    }
}
