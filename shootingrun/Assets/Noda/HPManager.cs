using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class HPManager : MonoBehaviour
{
<<<<<<< HEAD
    GameManagerSample _gameManagerSample;
=======
    private TimeManager tm;
    private ScoreManager sm;
>>>>>>> 39d6494ca484e019e2747ab168a1129620390377
    /// <summary>
    /// プレイヤーのライフポイント
    /// </summary>
    public int _hp = 5;
    void Start()
    {
<<<<<<< HEAD
        _gameManagerSample = GameManagerSample.GetInstancs;
        _hp = _gameManagerSample.Life;
=======
        tm = GetComponent<TimeManager>();
        sm = GetComponent<ScoreManager>();
        _hp = 3;
>>>>>>> 39d6494ca484e019e2747ab168a1129620390377
    }//hpの初期化

    void Damage(int damage)
    {
        _hp -= damage;
<<<<<<< HEAD
=======
        if (_hp <= 0)
        {
            float m = (tm.min * 60);
            tm._finishTime = tm.second + m;
            int i = (int)tm._finishTime;
            sm.Score += i;
        }//HPが０になったらタイムをScoreに加算
>>>>>>> 39d6494ca484e019e2747ab168a1129620390377
    }//ダメージを受けたときにhpを減らす
}
