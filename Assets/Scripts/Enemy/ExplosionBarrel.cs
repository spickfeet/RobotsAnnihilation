using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExplosionBarrel : MonoBehaviour, IDamageable
{
    [SerializeField] private GameObject _explosionPrefab;

    [SerializeField] private int _damage;
    [SerializeField] private int _health;
    [SerializeField] private float _damageRadius;

    private bool _isDestroy = false;

    public void ApplyDamage(int damage)
    {
        if(_isDestroy) return;
        _health -= damage;
        if(_health <= 0)
        {
            _isDestroy = true;
            Explosion();
        }
    }

    private void Explosion()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, _damageRadius);
        foreach (var collider in collider2Ds)
        {
            IDamageable target = collider.GetComponent<IDamageable>();
            if (target != null)
            {
                target.ApplyDamage(_damage);
            }
        }
        Instantiate(_explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _damageRadius);
    }
}
