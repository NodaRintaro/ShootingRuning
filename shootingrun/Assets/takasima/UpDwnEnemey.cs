using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDwnEnemey : MonoBehaviour
{
    [SerializeField] float _yMoveWidth = 1.5f;
    [SerializeField] float _speedY = 3f;
    [SerializeField] float _speedX = 5f;
    Vector2 _initailPosition;
    float _timer;

    void Start()
    {
        _initailPosition = this.transform.position;
    }
    void Update()
    {
        _timer += Time.deltaTime;
        float posY = Mathf.Sin(_timer * _speedY) * _yMoveWidth;
        float posX = (-1) * _timer * _speedX;
        Vector2 pos = _initailPosition + new Vector2(posX, posY);
        transform.position = pos;
        //左に移動
        if (this.transform.position.x < -120f)
        {
            Destroy(this.gameObject);
        }
        //行き過ぎたら消す
    }
}
