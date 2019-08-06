using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 200.0f;
    [SerializeField] private float _interactionTime = 0.5f;
    //[SerializeField] private List<GameObject> _gyukbos;

    private Rigidbody2D _rigid;
    private bool _canInteraction;
    private Home _interactionHome;
    private bool _isInteraction;

    void Start()
    {
        _isInteraction = false;
        _rigid = GetComponent<Rigidbody2D>();
        _interactionHome = null;
    }

    void FixedUpdate()
    {
        if (!_isInteraction)
        {
            Move();
            Rotate();

            if (Input.GetKeyDown(KeyCode.Space))            // Interaction!
                Interaction();
        }
        else
        {
            _rigid.velocity = Vector2.zero;
        }
    }

    void Move()
    {
        float translation = Input.GetAxis("Vertical") * _playerSpeed;
        float straffe = Input.GetAxis("Horizontal") * _playerSpeed;
        translation *= Time.fixedDeltaTime;
        straffe *= Time.fixedDeltaTime;

        _rigid.velocity = new Vector2(straffe, translation);
    }

    void Rotate()
    {
        if (Input.anyKey)
        {
            var curTarget = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            var angle = Mathf.Atan2(curTarget.y, curTarget.x) * Mathf.Rad2Deg;
            var rot = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.DORotate(rot.eulerAngles, 0.01f);
        }
    }

    void Interaction()
    {
        if (_canInteraction && !_isInteraction)
        {
            StartCoroutine(Interacting());
        }
    }

    IEnumerator Interacting()
    {
        _isInteraction = true;
        _interactionHome.TurnOff();
        yield return new WaitForSeconds(_interactionTime);
        _interactionHome._isDone = true;
        //Instantiate(_gyukbos[Random.Range(0, _gyukbos.Count)], transform.position, Quaternion.identity);
        Debug.Log("Active!");
        _isInteraction = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Home"))
        {
            _interactionHome = other.GetComponent<Home>();
            _canInteraction = !_interactionHome._isDone;
        }
        else if (other.CompareTag("Enemy"))
        {
            /// Game Over!
            _rigid.isKinematic = true;
            StageManager.Instance.OnGameFailure();
        }
        else if (other.CompareTag("EndZone"))
        {
            StageManager.Instance.OnGameSuccess();
        }
    }

    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    if (other.CompareTag("Home"))
    //    {
    //        //_interactionHome = other.GetComponent<Home>();
    //        _canInteraction = !_interactionHome._isDone;
    //    }
    //}

    private void OnTriggerExit2D(Collider2D other)
    {
        _interactionHome = null;
        _canInteraction = false;
    }
}
