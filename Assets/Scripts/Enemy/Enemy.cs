using Assets.Scripts.Enemy.Weapons;
using Assets.Scripts.Utilities;
using Assets.Scripts.Utilities.Sounds;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health;
    [SerializeField] private GameObject _destroyEffectPrefab;
    [SerializeField] private GameObject[] _dropPrefabs;
    [SerializeField] private int _chanceDropMedicKit;

    private bool _haveTeleporter = false;

    [SerializeField] private AudioClip _applyDamageSound;
    private ISoundManager _soundManager;

    private Animator _animator;


    [SerializeField] private int _currentHealth;

    public Action OnHealthChanged;
    public Action OnDead;

    public bool HaveTeleporter
    {
        get { return _haveTeleporter; }
        set { _haveTeleporter = value; }
    }

    public int MaxHealth
    {
        get { return _health; }
        set { _health = value; }
    }

    public int CurrentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }

    public GameObject DestroyEffectPrefab
    {
        get { return _destroyEffectPrefab;}
        set { _destroyEffectPrefab = value; }
    }

    private void Awake()
    {
        _currentHealth = _health;
        _soundManager = new SoundManager(GetComponent<AudioSource>(),SoundType.SFX);
        _animator = GetComponent<Animator>();
    }

    public void ApplyDamage(int damage)
    {
        _soundManager.PlayOneShot(_applyDamageSound);
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
        OnHealthChanged?.Invoke();

        _animator.Play("EnemyBlink");
    }
    public void Die()
    {
        DropItem();
        OnDead?.Invoke();
        Instantiate(_destroyEffectPrefab,transform.position,transform.rotation);
        Destroy(gameObject);
    }
    private void DropItem()
    {
        if (_dropPrefabs != null)
        {
            if (UnityEngine.Random.Range(0, 101) <= _chanceDropMedicKit)
            {
                if (_dropPrefabs[0] != null)
                    Instantiate(_dropPrefabs[0], transform.position, transform.rotation);
            }
            if (_haveTeleporter == true)
            {
                if (_dropPrefabs[1] != null)
                    Instantiate(_dropPrefabs[1], transform.position, transform.rotation);
            }
        }
    }
}
