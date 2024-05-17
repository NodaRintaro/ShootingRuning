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
    void Start()
    {
        _gameManagerSample = GameManagerSample.GetInstancs;
        _hp = _gameManagerSample.Life;
    }//hpの初期化

    void Damage(int damage)
    {
        _hp -= damage;
    }//ダメージを受けたときにhpを減らす
}
