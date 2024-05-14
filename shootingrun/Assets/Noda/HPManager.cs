using System.Collections;
using System.Collections.Generic;
using Singleton;
using UnityEngine;

class HPManager : SingletonMonoBehaviour<HPManager>
{
    /// <summary>
    /// プレイヤーのライフポイント
    /// </summary>
    public int _hp = 5;
    void Start()
    {
        _hp = 3;
    }//hpの初期化

    void Damage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            float m = (TimeManager.Instance.min * 60);
            TimeManager.Instance._finishTime = TimeManager.Instance.second + m;
            int i = (int)TimeManager.Instance._finishTime;
            ScoreManager.Instance.Score += i;
        }//HPが０になったらタイムをScoreに加算
    }//ダメージを受けたときにhpを減らす
}
