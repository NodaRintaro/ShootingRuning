using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Enemy : MonoBehaviour
{
    Rigidbody2D _rb = default;
    [SerializeField] private float _speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity -= new Vector2 (Time.deltaTime * _speed, 0); 
        //ç∂Ç…à⁄ìÆ
        if(this.transform.position.x < -120f)
        {
            Destroy(this.gameObject);
        }
        //çsÇ´âﬂÇ¨ÇΩÇÁè¡Ç∑
    }
}
