using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndMenuController : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Player _player;
    [SerializeField] private EndMenu _endMenu;
    [SerializeField] private Enemy _boss;

    [SerializeField] private bool _isInfinityMod;
    private bool _gameOver = false;

    private void OnEnable()
    {
         _player.OnDead += Lose;
        if (_boss != null)
            _boss.OnDead += Win;
    }

    private void Win()
    {
        if (_gameOver) return;
        _gameOver = true;
        if (PlayerPrefs.HasKey("ClassicModRecord"))
        {
            if (PlayerPrefs.GetInt("ClassicModRecord") > _timer.GetTimeSecond())
            {
                PlayerPrefs.SetInt("ClassicModRecord", _timer.GetTimeSecond());
            }
        }
        else PlayerPrefs.SetInt("ClassicModRecord", _timer.GetTimeSecond());

        _timer.Stop();
        _endMenu.ActiveMenu("YOU WIN :)\nTIME: " + _timer.GetTimeSecond());
    }

    private void Lose()
    {
        if (_gameOver) return;
        _gameOver = true;
        if (_isInfinityMod)
        {
            if (PlayerPrefs.HasKey("InfinityModRecord"))
            {
                if (PlayerPrefs.GetInt("InfinityModRecord") < _timer.GetTimeSecond())
                {
                    PlayerPrefs.SetInt("InfinityModRecord", _timer.GetTimeSecond());
                }
            }
            else PlayerPrefs.SetInt("InfinityModRecord", _timer.GetTimeSecond());
        }
        _timer.Stop();
        _endMenu.ActiveMenu("YOU LOSE :(\nLIVE TIME: " + _timer.GetTimeSecond());
    }
}
