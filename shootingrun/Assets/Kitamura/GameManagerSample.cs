using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 仮のスクリプト
/// </summary>
public class GameManagerSample : MonoBehaviour
{
    static GameManagerSample instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static GameManagerSample GetInstancs
    {
        get
        {
            return instance;
        }
    }

    public int Life { get => _life; set => _life = value; }
    public int MaxLife { get => _maxLife; set => _maxLife = value; }
    public int Score { get => _score; set => _score = value; }
    public float Time { get => _time; set => _time = value; }
    public int ResultScore { get => _resultScore; }
    public bool GameoverFlag { get => _gameoverFlag; }

    [SerializeField,Range(0,10)] int _life = 3;
    [SerializeField] int _maxLife = 10;
    [SerializeField] int _score = 100000;
    [SerializeField] float _time = 0;
    int _resultScore = 0;
    [SerializeField] GameObject _resultUI;
    bool _gameoverFlag = false;

    private void Start()
    {
        _resultUI.SetActive(false);
    }

    void Update()
    {
        if (Life <= 0) 
        {
            _gameoverFlag = true;
        }
        else
        {
            _time += UnityEngine.Time.deltaTime;
        }

        if (GameoverFlag) 
        {
            Gameover();
            _gameoverFlag = false;
        }
    }

    void Gameover()
    {
        _resultScore = _score + (int)(_time * 100);
        _resultUI.SetActive(true);
    }
}
