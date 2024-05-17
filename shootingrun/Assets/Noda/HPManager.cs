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
        _hp = _gameManagerSample.Life;
        time = _gameManagerSample.Time;
    }//hp初期化

    void Damage(int damage)
    {
        _hp -= damage;
        if (_hp == 0)
        {
            int _time = (int)time;
            ScoreManager.Instance.Hit(_time);
        }
    }//ダメージを受けたときにhpを減らす
}
