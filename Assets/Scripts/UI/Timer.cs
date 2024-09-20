using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    private float _time;
    private bool _isRunning = true;

    public int GetTimeSecond()
    {
        return (int)_time;
    }
    private void Update()
    {
        if (_isRunning)
        {
            _time += Time.deltaTime;
            _textMeshPro.text = ((int)_time).ToString();
        }
    }

    public void Stop()
    {
        _isRunning = false;
        gameObject.SetActive(false);
    }
}
