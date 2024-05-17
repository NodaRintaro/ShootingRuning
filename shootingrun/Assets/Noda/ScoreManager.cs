using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ScoreManager : MonoBehaviour
{
    GameManagerSample _gameManagerSample;    
    /// <summary>
    /// 合計のScore
    /// </summary>
    public int Score { get; set; }
    void Start()
    {
        _gameManagerSample = GameManagerSample.GetInstancs;
        Score = _gameManagerSample.Score;
    }//Scoreの初期化

    public void Hit(int enemyPoint)
    {
        Score += enemyPoint;
    }//Enemy撃破時にScoreを加算する
}
