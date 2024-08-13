using Assets.Scripts.Enemy.Weapons;
using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
        Debug.Log(_health);
        _animator.Play("EnemyBlink");
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
