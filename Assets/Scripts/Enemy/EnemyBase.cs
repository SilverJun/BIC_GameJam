using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private float _patrolTime;     // 패트롤 
    [SerializeField] private float _patrolWaitTime;     // 패트롤 하고 대기하는 시간.

    [SerializeField] private Transform _enemy;
    [SerializeField] private List<Transform> _points = new List<Transform>();
    [SerializeField] private bool _isLastCheck = false;

    private Sequence _rotationSeq;
    private Sequence _moveSeq;
    //private bool _isRotating = false;
    void Start()
    {
        StartCoroutine(Patrol());
    }

    public IEnumerator Patrol()
    {
        int i = 0;
        while (true)
        {
            var curTarget = _points[i % _points.Count];

            /// 0. 지정된 타겟으로 회전한다.

            var dir = curTarget.position - _enemy.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            var rot = Quaternion.AngleAxis(angle, Vector3.forward);

            _rotationSeq = DOTween.Sequence();
            _rotationSeq.Append(_enemy.DORotate(rot.eulerAngles, 1.0f));
            _rotationSeq.Play();
            yield return new WaitWhile(() => _rotationSeq.IsPlaying());

            // Debug.Log(i);

            /// 1. 정해진 위치까지 간다.
            _moveSeq = DOTween.Sequence();
            _moveSeq.SetEase(Ease.Linear);
            _moveSeq.Append(_enemy.DOMove(curTarget.position, dir.magnitude/_patrolTime /*_patrolTime*/));
            _moveSeq.Play();
            yield return new WaitWhile(() => _moveSeq.IsPlaying());

            if (_isLastCheck)
            {
                /// 2. 정해진 위치에 도착하면 회전한다.
                //_isRotating = true;
                _rotationSeq = DOTween.Sequence();
                var durationTime = _patrolWaitTime / 8.0f;
                _rotationSeq.Append(_enemy.DORotate(new Vector3(0, 0, _enemy.rotation.eulerAngles.z + 60), durationTime));
                _rotationSeq.Append(_enemy.DORotate(new Vector3(0, 0, _enemy.rotation.eulerAngles.z - 60), durationTime * 2));
                _rotationSeq.Append(_enemy.DORotate(new Vector3(0, 0, _enemy.rotation.eulerAngles.z), durationTime));
                _rotationSeq.SetEase(Ease.InOutSine);
                _rotationSeq.Play();
                yield return new WaitWhile(() => _rotationSeq.IsPlaying());
            }
            i++;
        }
    }
}
