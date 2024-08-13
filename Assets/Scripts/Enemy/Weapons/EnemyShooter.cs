using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemy.Weapons
{
    class EnemyShooter : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private Player _player;


        [SerializeField] private float _bulletSpeed;
        [SerializeField] private float _attackRange;

        [SerializeField] private float _nextAttackTime;
        private float _nextAttackTimer;

        private ShootRotation _shootRotation;

        private void Awake()
        {
            _shootRotation = new(_player.transform);
        }

        private void Update()
        {
            _shootPoint.rotation = _shootRotation.ChangeRotation(_shootPoint.transform.position, 0);
            if (Vector3.Distance(transform.position, _player.transform.position) <= _attackRange)
            {
                if (_nextAttackTimer <= 0)
                {
                    Shoot();
                    _nextAttackTimer = _nextAttackTime;
                }
                _nextAttackTimer -= Time.deltaTime;
            }


        }

        public void Shoot()
        {
            GameObject bullet = Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * _bulletSpeed;
        }
    }
}
