using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class HPManager : MonoBehaviour
{
    private TimeManager tm;
    private ScoreManager sm;
    /// <summary>
    /// プレイヤーのライフポイント
    /// </summary>
    public int _hp = 5;
    void Start()
    {
        tm = GetComponent<TimeManager>();
        sm = GetComponent<ScoreManager>();
        _hp = 3;
    }//hpの初期化

    void Damage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            float m = (tm.min * 60);
            tm._finishTime = tm.second + m;
            int i = (int)tm._finishTime;
            sm.Score += i;
        }//HPが０になったらタイムをScoreに加算
    }//ダメージを受けたときにhpを減らす
}
