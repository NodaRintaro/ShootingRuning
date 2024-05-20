using System;
using System.Collections;
using System.Collections.Generic;
using Singleton;
using UnityEngine;

class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{
    GameManagerSample _gameManager;
    /// <summary>
    /// 合計Score
    /// </summary>
    public int Score { get; set; }
    void Start()
    {
        _gameManager = GameManagerSample.GetInstancs;
    }//Scoreの初期化

    public void Hit(int enemyPoint)
    {
        _gameManager.Score += enemyPoint;
    }//Enemy撃破時にScoreを加算する
}
