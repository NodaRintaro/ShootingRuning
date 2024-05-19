using System;
using System.Collections;
using System.Collections.Generic;
using Singleton;
using UnityEngine;

class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{
    GameManagerSample _gameManagerSample;    
    /// <summary>
    /// 合計Score
    /// </summary>
    public int Score { get; set; }
    void Start()
    {
        _gameManagerSample = GameManagerSample.GetInstancs;
    }//Scoreの初期化

    public void Hit(int enemyPoint)
    {
        _gameManagerSample.Score += enemyPoint;
    }//Enemy撃破時にScoreを加算する
}
