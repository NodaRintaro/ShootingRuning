using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ScoreManager : MonoBehaviour
{
    /// <summary>
    /// 合計Score
    /// </summary>
    public int Score { get; set; }
    void Start()
    {
        Score = 0;
    }//Scoreの初期化

    public void Hit(int enemyPoint)
    {
        Score += enemyPoint;
    }//Enemy撃破時にScoreを加算する
}
