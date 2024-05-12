using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int _hp = 5;
    //PlayerHP
    private int _score = 0;

    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
        }
    }

    public void ScorePlus(int ePoint)
    {
        _score += ePoint;
    }

    public void HpPlus(int damage)
    {
        _hp += damage;
    }
}
