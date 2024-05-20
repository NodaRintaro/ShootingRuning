using System;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] GameObject _target;
    [SerializeField] float _bulletSpeed = 5;
    [SerializeField] float _interval = 1;
    Vector3 _mousePos;          //マウスカーソルの座標を入れる変数
    Vector3 _cursorDistance;
    float _timer;
    bool _isClick;

    void Awake()
    {
        _timer = 20;
    }

    void Start()
    {
        _timer = 100;
    }

    void Update()
    {
        _mousePos = Input.mousePosition;                            //マウスカーソルの座標を取得して変数に入れる
        _mousePos = Camera.main.ScreenToWorldPoint(_mousePos);
        _mousePos.z = 0;
        _target.transform.position = _mousePos;
        if (_isClick)
        {
            if (Input.GetButton("Fire1"))
            {
                GameObject bullet = Instantiate(_bullet, transform.position, Quaternion.identity);              //弾を生成
                if (_bullet.GetComponent<Rigidbody2D>() != null)
                {
                    Rigidbody2D bulletRigidbody2D = bullet.GetComponent<Rigidbody2D>();                         //_bulletのRigidbodyを取得
                    //Vector3.Scaleは2つのベクトルのxyzをかけている
                    _cursorDistance = Vector3.Scale((_mousePos - transform.position), new Vector3(1, 1, 0)).normalized;
                    bulletRigidbody2D.velocity = _cursorDistance * _bulletSpeed;
                }
                else
                {
                    Debug.Log("Rigidbody2Dが付いてないよ♡");
                }
                _isClick = false;
            }   
        }
        else
        {
            _timer += Time.deltaTime;
        }
        if (_timer > _interval)
        {
            _timer = 0;
            _isClick = true;
        }
    }

    public void IntervalValueChange(float value)
    {
        _interval += value;
    }
}