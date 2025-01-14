using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private int _damage;

    [SerializeField] private GameObject _hitEffectPrefab;

    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    private void Update()
    {
        _lifeTime -= Time.deltaTime;
        if (_lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable target = collision.GetComponent<IDamageable>();
        if (target != null)
        {
            target.ApplyDamage(_damage);
        }

        

        Instantiate(_hitEffectPrefab, transform.position, transform.rotation).transform.Rotate(0, 0, Random.Range(0, 360));
        Destroy(this.gameObject);
    }
}
