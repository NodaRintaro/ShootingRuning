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
    [Header("Hpをどのぐらい減少させるかの値"), SerializeField] int _MinusHp = 1;
    [Header("スコアにプラスする値"), SerializeField] int _PlusScoer = 5;
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
        //左に移動
        if(this.transform.position.x < -120f)
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
