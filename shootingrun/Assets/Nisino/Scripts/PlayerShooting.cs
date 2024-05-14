using System;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject _mouseCursor;
    [SerializeField] GameObject _bullet;
    [SerializeField] float _bulletSpeed = 5;
    [SerializeField] float _interval = 1;
    Vector3 _mousePos;          //マウスカーソルの座標を入れる変数
    Vector3 _cursorDistance;
    float _timer;
    bool _isClick;

    void Start()
    {
        _timer = 100;
    }

    void Update()
    {
        _mousePos = Input.mousePosition;                            //マウスカーソルの座標を取得して変数に入れる
        _mousePos = Camera.main.ScreenToWorldPoint(_mousePos);      
        _mousePos.z = 0;
        _mouseCursor.transform.position = _mousePos;
        if (_isClick)
        {
            if (Input.GetButton("Fire1"))
            {
                GameObject bullet = Instantiate(_bullet, transform.position, Quaternion.identity);              //弾を生成
                if (_bullet.GetComponent<Rigidbody2D>() != null)
                {
                    Rigidbody2D bulletRigidbody2D = bullet.GetComponent<Rigidbody2D>();                         //_bulletのRigidbodyを取得
                    _cursorDistance = _mouseCursor.transform.position - transform.position;                     //マウスカーソルとプレイヤーのベクトルを取得
                    bulletRigidbody2D.AddForce(_cursorDistance * _bulletSpeed,ForceMode2D.Impulse);           //_bulletのRigidbodyを使って_bulletを飛ばす
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