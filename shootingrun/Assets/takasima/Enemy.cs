using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    Vector2 _transformposition;
    float _timer;
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
        //ç∂Ç…à⁄ìÆ
        if(this.transform.position.x < -120f)
        {
            Destroy(this.gameObject);
        }
        //çsÇ´âﬂÇ¨ÇΩÇÁè¡Ç∑
    }
}
