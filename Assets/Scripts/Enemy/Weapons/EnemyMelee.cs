using Assets.Scripts.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemy.Weapons
{
    public class EnemyMelee : MonoBehaviour
    {
        [SerializeField] private int _damage;

        [SerializeField] private float _nextAttackTime;
        private float _nextAttackTimer;

        private void Update()
        {
            if (_nextAttackTimer > 0)
            {
                _nextAttackTimer -= Time.deltaTime;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IDamageable _target = collision.GetComponent<IDamageable>();
            if (_target != null && _nextAttackTimer <= 0 )
            {
                _target.ApplyDamage(_damage);
                _nextAttackTimer = _nextAttackTime;
            }
        }
    }
}
