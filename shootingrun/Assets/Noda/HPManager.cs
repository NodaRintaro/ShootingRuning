using System.Collections;
using System.Collections.Generic;
using Singleton;
using UnityEngine;
using UnityEngine.SceneManagement;

class HPManager : SingletonMonoBehaviour<HPManager>
{
    
    GameManagerSample _gameManager;
    
    /// <summary>
    /// プレイヤーのライフポイント
    /// </summary>
    public int _hp = 5;

    public float time;
    void Start()
    {
        _gameManager = GameManagerSample.GetInstancs;
    }//hp初期化

    public void Damage(int damage)
    {
        _gameManager.Life -= damage;
        if (_gameManager.Life <= 0)
        {
            int _time = (int)_gameManager.Time;
            ScoreManager.Instance.Hit(_time);
            SceneManager.LoadScene("GameOver");
        }
    }//ダメージを受けたときにhpを減らす
}
