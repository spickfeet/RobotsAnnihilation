using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField] private Enemy _boss;
    [SerializeField] private Image _healthBarImage;

    private void Awake()
    {
        _boss.OnHealthChanged += ChangeHealth;
    }

    public void ChangeHealth()
    {
        _healthBarImage.fillAmount = (float)_boss.CurrentHealth/ (float)_boss.MaxHealth;
    }
}
