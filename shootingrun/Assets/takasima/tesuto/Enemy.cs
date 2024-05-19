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
    Rigidbody _rb;
    // Start is called before the first frame update

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        transform.position -= new Vector3(Time.deltaTime * _speed, 0);
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
            HPManager.Instantiate.Hp(_MinusHp);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            ScoreManager.Instantiate.Hit(_PlusScoer);
            Destroy(this.gameObject);
        }
    }

}
