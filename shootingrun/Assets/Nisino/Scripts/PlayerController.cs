using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public int Hp { private get; set; }
    Rigidbody2D _rb;
    [SerializeField] float _jumpPower;
    Vector2 _jumpVector;
    bool _isGround;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _jumpVector = new Vector2(0, _jumpPower * 5);
        _isGround = true;
    }

    void Update()
    {
        if (_isGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rb.AddForce(_jumpVector, ForceMode2D.Impulse);
                _isGround = false;
            }   
        }
    }

    public void HpValueChange(int value)
    {
        Hp += value;
    }

    public void JumpPowerValueChange(int value)
    {
        _jumpVector = new Vector2(0, value * 5);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) //Enemyタグが付いたオブジェクトに触れたらHpを減らす
        {
            HpValueChange(-1);
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            _isGround = true;

            Debug.Log("押された");
        }
    }
}