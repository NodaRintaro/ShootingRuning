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

    [Header("Hp���ǂ̂��炢���������邩�̒l"), SerializeField] int _MinusHp = 1;
    [Header("�X�R�A�Ƀv���X����l"), SerializeField] int _PlusScoer = 5;
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
        //���Ɉړ�
        if (this.transform.position.x < -100f)
        {
            Destroy(this.gameObject);
        }
        //�s���߂��������
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HPManager.Instance.Hp(_MinusHp);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            ScoreManager.Instance.Hit(_PlusScoer);
            Destroy(this.gameObject);
        }
    }
}
