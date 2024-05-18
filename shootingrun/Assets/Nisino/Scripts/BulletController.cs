using System;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    float _timer;
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > 2)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);   
        }
    }
}