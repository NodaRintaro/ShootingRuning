using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 仮のスクリプト
/// </summary>
public class GameManagerSample : MonoBehaviour
{
    static GameManagerSample instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static GameManagerSample GetInstancs
    {
        get
        {
            return instance;
        }
    }

    public int Life { get => life; set => life = value; }
    public int MaxLife { get => maxLife; set => maxLife = value; }
    public int Score { get => score; set => score = value; }
    public float Time { get => time; set => time = value; }

    [SerializeField,Range(0,10)] int life = 3;
    [SerializeField] int maxLife = 10;
    [SerializeField] int score = 100000;
    [SerializeField] float time = 0;

    void Update()
    {
        Time += UnityEngine.Time.deltaTime;
    }
}
