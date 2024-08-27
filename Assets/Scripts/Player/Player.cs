using Assets.Scripts.Inventory;
using Assets.Scripts.Inventory.Items;
using Assets.Scripts.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Utilities.Sounds;

[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private float _timeImmortalityAfterDamage;

    [SerializeField] private float _interactableRadius;

    [SerializeField] private LayerMask _interactableLayer;
    [SerializeField] private GameObject _pressE;


    [SerializeField] private AudioClip _applyDamageSound;
    [SerializeField] private AudioClip _applyHealSound;
    [SerializeField] private AudioClip _lowHPSound;
    private ISoundManager _soundManager;


    private int _currentHealth;
    private Inventory _inventory;

    private Animator _animator;

    private bool _damageable = true;


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
    public Action<int> OnHealthChanged;

    private void Awake()
    {
        _soundManager = new SoundManager(GetComponent<AudioSource>(), SoundType.SFX);

        _animator = GetComponent<Animator>();

        _inventory = new(new List<IItem>());
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, _interactableRadius, _interactableLayer);

        if(collider2Ds.Length > 0)
        {
            _pressE.SetActive(true);
        }
        else 
        { 
            _pressE.SetActive(false); 
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact(collider2Ds);
        }
    }

    private void Interact(Collider2D[] collider2Ds)
    {
        foreach (var collider2D in collider2Ds)
        {
            if (collider2D.TryGetComponent<IInteractable>(out IInteractable interactable)) 
            {
                interactable.Interact();
            }
        }
        
    }

    public void ApplyImmortality(float time)
    {
        if(_damageable == true)
         StartCoroutine(Immortality(time));
    }

    private IEnumerator Immortality(float time)
    {
        _damageable = false;
        yield return new WaitForSeconds(time);
        _damageable = true;
        _animator.Play("PlayerIdle");
    }

    public void ApplyDamage(int damage)
    {
        if (_damageable == false) { return; }

        if (damage < 0) throw new ArgumentException("Урон не может быть отрицательным");
        _currentHealth -= damage;
        OnHealthChanged.Invoke(_currentHealth);
        if (_currentHealth <= 0)
        {
            Die();
            return;
        }

        if(_currentHealth * 4 <= _maxHealth) _soundManager.PlayOneShot(_lowHPSound);
        else _soundManager.PlayOneShot(_applyDamageSound);

        _animator.Play("PlayerImmortal");
        ApplyImmortality(_timeImmortalityAfterDamage);
    }

    public void ApplyHeal(int health) 
    {
        if (health < 0) throw new ArgumentException("Лечение не может быть отрицательным");
        _currentHealth += health;
        _soundManager.PlayOneShot(_applyHealSound);


        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        OnHealthChanged.Invoke(_currentHealth);
       
    }
    public void Die()
    {
        OnDead?.Invoke();
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _interactableRadius);
    }
}
