using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class HPManager : MonoBehaviour
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
        TimeManager tm = GetComponent<TimeManager>();
        ScoreManager sm = GetComponent<ScoreManager>();
        _hp -= damage;
        if (_hp == 0)
        {
            float m = (tm.min * 60);
            tm._finishTime = tm.second + m;
            int i = (int)tm._finishTime;
            sm.Score += i;
        }//HPが０になったらタイムをScoreに加算
    }//ダメージを受けたときにhpを減らす
}
