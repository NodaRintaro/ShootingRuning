using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/// <summary>
/// Score、Time、Lifeの表示
/// </summary>
public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text _scoreText;
    [SerializeField] TMP_Text _timeText;
    [SerializeField] GameObject _lifeGage;//Lifeのオブジェクトが入っている親
    [SerializeField] GameObject _lifePrehub;//Lifeのプレハブ
    [SerializeField] GameObject _lifeBuckground;//Lifeの背景のプレハブ
    GameManagerSample _gameManagerSample;
    GameObject _lifeGageBack;
    GameObject _LifeGageFront;
    List<Life> _lifes = new();
    int _lifesCount;
    ///<summary>Lifeの値が変化した時参照する値</summary>
    int _oldLifeValue;
    ///<summary>Scoreの値が変化した時参照する値</summary>
    int _oldScoreValue;
    ///<summary>Scoreの変化量に対して一定時間で補間する時に使う値</summary>
    int _ScoreValueDiff;
    Life _life;
    void Start()
    {
        _gameManagerSample = GameManagerSample.GetInstancs;
        _lifeGageBack = _lifeGage.transform.Find("LifeGageBack").gameObject;
        _LifeGageFront = _lifeGage.transform.Find("LifeGageFront").gameObject;
        _oldLifeValue = _gameManagerSample.MaxLife;
        _oldScoreValue = _gameManagerSample.Score;
        while (_lifeGageBack.transform.childCount <= _gameManagerSample.MaxLife)
        {
            Instantiate(_lifeBuckground, _lifeGageBack.transform);
        }//ライフの最大値までライフの背景を生成
        while (_LifeGageFront.transform.childCount <= _gameManagerSample.MaxLife)
        {
            GameObject tmp = Instantiate(_lifePrehub, _LifeGageFront.transform);
            tmp.name = $"LifeClone {_lifesCount++}";
            _lifes.Add(tmp.GetComponent<Life>());
        }//ライフの最大値までライフを生成、リストに追加
    }

    void Update()
    {
        TextDraw();
        if (_gameManagerSample.Life < _oldLifeValue)
        {
            Damage();
            _oldLifeValue--;
        }//lifeが減った時
        if (_gameManagerSample.Life > _oldLifeValue)
        {
            Recover();
            _oldLifeValue++;
        }//Lifeが増えた時
        if (_oldScoreValue != _gameManagerSample.Score)
        {
            ScoreInterpolation();
            if(_ScoreValueDiff != _gameManagerSample.Score)
            {
                _ScoreValueDiff = _gameManagerSample.Score;
            }
        }
    }

    void Damage()
    {
        _life = _lifes[_oldLifeValue - 1];
        _life.HeartMinus();
    }

    void Recover()
    {
        _life = _lifes[_oldLifeValue];
        _life.HeartPlus();
    }

    void ScoreInterpolation()
    {
        if (_oldScoreValue < _gameManagerSample.Score)
        {
            _oldScoreValue += (int)(Time.deltaTime *(_ScoreValueDiff));
        }
        else if (_oldScoreValue >= _gameManagerSample.Score)
        {
            _oldScoreValue = _gameManagerSample.Score;
        }
    }//スコアの変化を補間
    void TextDraw()
    {
        //score表示0埋め６桁（スコア　000000）
        _scoreText.text = $"スコア {_oldScoreValue:000000}";
        //time表示0埋め２桁（タイム　00:00）
        _timeText.text = $"タイム　{_gameManagerSample.Time:00}:{(int)(_gameManagerSample.Time % 1 * 100):00}";

    }
}
