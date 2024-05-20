using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
/// <summary>
/// ���U���g�X�R�A��UI�Ƃ��ďo��
/// </summary>
public class Result : MonoBehaviour
{
    GameManagerSample _gameManagerSample;
    [SerializeField] TMP_Text _timeText;
    [SerializeField] TMP_Text _scoreText;
    [SerializeField] TMP_Text _resultScoreText;
    int _score;
    float _time;
    int _resultScore;
    string _timemold;
    void Awake()
    {
        gameObject.SetActive(false);
    }
    void Start()
    {
        _gameManagerSample = GameManagerSample.GetInstancs;
        SetDate();
    }
    void Update()
    {
        TextDraw();
    }

    void SetDate()
    {
        _score = _gameManagerSample.Score;
        _time = (_gameManagerSample.Time * 100);
        _resultScore = _gameManagerSample.ResultScore;
        _timemold =
            _time > 1000000 ?
            $"{_time.ToString().Substring(0, 5)}:{_time.ToString().Substring(5, 2)}" :
            _time > 100000 ?
            $"{_time.ToString().Substring(0, 4)}:{_time.ToString().Substring(4, 2)}" :
            _time > 10000 ?
            $"{_time.ToString().Substring(0, 3)}:{_time.ToString().Substring(3, 2)}" :
            _time > 1000 ?
            $"{_time.ToString().Substring(0, 2)}:{_time.ToString().Substring(2, 2)}" :
            $"{_time.ToString().Substring(0, 1)}:{_time.ToString().Substring(1, 2)}";
    }

    void TextDraw()
    {
        //score�\��0���߂U���i�X�R�A�@000000�j
        _scoreText.text = $"�X�R�A\n{_score}";
        //time�\��0���߂Q���i�^�C���@00:00�j
        _timeText.text = $"�^�C��\n" + _timemold;
        _resultScoreText.text = $"���U���g�X�R�A\n{_resultScore}";
    }
}
