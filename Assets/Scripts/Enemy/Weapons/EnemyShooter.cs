using Assets.Scripts.Utilities;
using Assets.Scripts.Utilities.Sounds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Assets.Scripts.Enemy.Weapons
{
    [RequireComponent(typeof(AudioSource))]
    class EnemyShooter : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private Player _player;

        [SerializeField] private float _bulletSize = 1;

        [SerializeField] private int _damage;
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private float _attackRange;

        [SerializeField] private float _nextAttackTime;

        [SerializeField] private AudioClip _shootSound;
        private ISoundManager _soundManager;


        private float _nextAttackTimer;

        private ShootRotation _shootRotation;

        private void Awake()
        {
            _soundManager = new SoundManager(GetComponent<AudioSource>(), SoundType.SFX);
            _player = FindAnyObjectByType<Player>();
        }

        private void Start()
        {
            if(_player != null)
                _shootRotation = new(_player.transform);
        }

        private void Update()
        {
            if (_player == null) return;
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
            _soundManager.PlayOneShot(_shootSound);
            GameObject bullet = Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
            bullet.transform.localScale *= _bulletSize;
            Light2D bulletLight = bullet.GetComponent<Light2D>();
            bulletLight.pointLightInnerRadius *= _bulletSize;
            bulletLight.pointLightOuterRadius *= _bulletSize;
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * _bulletSpeed;
            bullet.GetComponent<Bullet>().Damage = _damage;
        }
    }
}
