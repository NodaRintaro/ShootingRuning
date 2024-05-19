using System.Collections;
using System.Collections.Generic;
using Singleton;
using UnityEngine;

class HPManager : SingletonMonoBehaviour<HPManager>
{
    GameManagerSample _gameManagerSample;
    
    /// <summary>
    /// プレイヤーのライフポイント
    /// </summary>
    public int _hp = 5;

    public float time;
    void Start()
    {
        _gameManagerSample = GameManagerSample.GetInstancs;
    }//hp初期化

    public void Damage(int damage)
    {
        _gameManagerSample.Life -= damage;
        if (_gameManagerSample.Life == 0)
        {
            int _time = (int)_gameManagerSample.Time;
            ScoreManager.Instance.Hit(_time);
        }
    }//ダメージを受けたときにhpを減らす
}
