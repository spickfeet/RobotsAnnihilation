using Assets.Scripts.Inventory;
using Assets.Scripts.Inventory.Items;
using Assets.Scripts.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private float _timeImmortalityAfterDamage;

    private int _currentHealth;
    private Inventory _inventory;

    private Animator _animator;

    private bool _isDamageable = true;


    public int CurrentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }
    public int MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }
    public Inventory Inventory
    {
        get { return _inventory; }
        set { _inventory = value; }
    }

    public Action OnDead;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        _inventory = new(new List<IItem>());
        _currentHealth = _maxHealth;
    }

    public void ApplyImmortality(float time)
    {
        StartCoroutine(Immortality(time));
    }

    private IEnumerator Immortality(float time)
    {
        _isDamageable = false;
        yield return new WaitForSeconds(time);
        _isDamageable = true;
        _animator.Play("PlayerIdle");
    }

    public void ApplyDamage(int damage)
    {
        if (_isDamageable == false) { return; }

        if (damage < 0) throw new ArgumentException("Урон не может быть отрицательным");
        _currentHealth -= damage;
        
        if (_currentHealth <= 0)
        {
            Debug.Log("You Lose");
            OnDead?.Invoke();
            return;
        }
        Debug.Log(_currentHealth);
        _animator.Play("PlayerImmortal");
        ApplyImmortality(_timeImmortalityAfterDamage);
    }

    public void ApplyHeal(int health) 
    {
        if (health < 0) throw new ArgumentException("Лечение не может быть отрицательным");
        _currentHealth += health;
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }

}
