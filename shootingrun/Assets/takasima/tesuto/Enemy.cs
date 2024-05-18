using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    Vector2 _transformposition;
    float _timer;
    float _HpEnemey;
    [Header("Hp���ǂ̂��炢���������邩�̒l"), SerializeField] int _MinusHp = 1;
    [Header("�X�R�A�Ƀv���X����l"), SerializeField] int _PlusScoer = 5;
    private HPManager _hpMg;
    private ScoreManager _score;
    // Start is called before the first frame update
    
    void Start()
    {
        _transformposition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
       Vector2 pos =  _transformposition  +  new Vector2 ( (-1)* _timer* _speed, 0); 
      _transformposition = pos;
        //���Ɉړ�
        if(this.transform.position.x < -120f)
        {
            Destroy(this.gameObject);
        }
        //�s���߂��������

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
