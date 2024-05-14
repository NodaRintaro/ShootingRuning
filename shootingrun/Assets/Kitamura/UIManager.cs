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
    int _oldLifeValue;
    Life _life;
    void Start()
    {
        _gameManagerSample = GameManagerSample.GetInstancs;
        _lifeGageBack = _lifeGage.transform.Find("LifeGageBack").gameObject;
        _LifeGageFront = _lifeGage.transform.Find("LifeGageFront").gameObject;
        _oldLifeValue = _gameManagerSample.MaxLife;
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
        if(_gameManagerSample.Life < _oldLifeValue)
        {
            Damage();
            _oldLifeValue--;
        }//lifeが減った時
        if (_gameManagerSample.Life > _oldLifeValue)
        {
            Recover();
            _oldLifeValue++;
        }//Lifeが増えた時
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

    void TextDraw()
    {
        //score表示0埋め６桁（スコア　000000）
        _scoreText.text = $"スコア {_gameManagerSample.Score:000000}";
        //time表示0埋め２桁（タイム　00:00）
        _timeText.text = $"タイム　{_gameManagerSample.Time:00}:{(int)(_gameManagerSample.Time % 1 * 100):00}";
    }
}
