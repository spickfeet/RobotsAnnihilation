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

    private void OnEnable()
    {
         _player.OnDead += Lose;
        if (_boss != null)
            _boss.OnDead += Win;
    }

    private void Win()
    {
        _timer.Stop();
        _endMenu.ActiveMenu("YOU WIN :)\nTIME: " + _timer.GetTimeSecond());
    }

    private void Lose()
    {
        _timer.Stop();
        _endMenu.ActiveMenu("YOU LOSE :(\nLIVE TIME: " + _timer.GetTimeSecond());
    }
}
