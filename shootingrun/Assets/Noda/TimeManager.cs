using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class TimeManager : MonoBehaviour
{
    /// <summary>
    /// 終わった時のScoreに加算する時間
    /// </summary>
    public float _finishTime = 0;
    
    /// <summary>
    /// 秒数
    /// </summary>
    public float second { get; set; }
    /// <summary>
    /// 分
    /// </summary>
    public float min { get; set; }
    void Start()
    {
        second = 0.0f;
        min = 0;
    }//時間の初期化
    
    void Update()
    {
        second += Time.deltaTime;
        if (second >= 60)
        {
            min += 1;
            second = 0;
            Debug.Log("1分経過");
        }//60秒を1分に直す
    }//時間の計測
}
