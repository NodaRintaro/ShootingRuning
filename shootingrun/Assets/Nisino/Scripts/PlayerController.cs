using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    public int Hp {private get; set; }
    Rigidbody2D _rb;
    [SerializeField] float _jumpPower;
    Vector2 _jumpVector;
    bool _isGround;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _jumpVector = new Vector2(0, _jumpPower);
    }
    
    void Update()
    {
        if (_isGround)
        {
            if (Input.GetButtonDown("Jump"))
            {
                _rb.AddForce(_jumpVector,ForceMode2D.Impulse);
            }   
        }
    }
    
    public void HpValueChange(int value)
    {
        Hp += value;
    }

    public void JumpPowerValueChange(int value)
    {
        _jumpVector = new Vector2(0, value);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (CompareTag("Enemy"))    //Enemyタグが付いたオブジェクトに触れたらHpを減らす
        {
            HpValueChange(-1);
        }
    }
}
