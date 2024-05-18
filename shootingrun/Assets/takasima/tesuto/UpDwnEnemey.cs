using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class UpDwnEnemey : MonoBehaviour
{
    [SerializeField] float _yMoveWidth = 1.5f;
    [SerializeField] float _speedY = 3f;
    [SerializeField] float _speedX = 5f;
    Vector2 _initailPosition;
    float _timer;
    float _HpEnemey;
    [Header("Hpをどのぐらい減少させるかの値"), SerializeField] int _MinusHp = 1;
    [Header("スコアにプラスする値"), SerializeField] int _PlusScoer = 5;
    private HPManager _hpMg;
    private ScoreManager _score;

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
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _hpMg._hp = 1;
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _score.Score = _PlusScoer;
            Destroy(this.gameObject);
        }
    }
}
