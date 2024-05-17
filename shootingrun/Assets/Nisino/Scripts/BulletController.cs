using UnityEngine;

public class BulletController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //エネミーのHPを減らす処理を追加する
        }
        if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);   
        }
    }
}