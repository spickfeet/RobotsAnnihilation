using Assets.Scripts.Utilities;
using Assets.Scripts.Utilities.Sounds;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerGun : MonoBehaviour
{
    [SerializeField] private CameraController _controller;

    [SerializeField] private float _nextShootTime;

    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletSpeed;

    [SerializeField] private Transform _centerOfCircle;

    [SerializeField] private AudioClip _shootSound;
    private ISoundManager _soundManager;

    [SerializeField] private float _nextShootTimer;


    private PlayerWeaponRotation _weaponRotation = new();
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _nextShootTimer = _nextShootTime;
        _soundManager = new SoundManager(GetComponent<AudioSource>(), SoundType.SFX);
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        (_centerOfCircle.transform.rotation, _spriteRenderer.flipY) = _weaponRotation.ChangeRotation(_centerOfCircle.transform.position, 0);
        if(Input.GetMouseButton(0) && _nextShootTimer <= 0)
        {
            Shoot();
        }
        if(_nextShootTimer > 0)
        {
            _nextShootTimer -= Time.deltaTime;
        }

    }

    private void Shoot()
    {
        _nextShootTimer = _nextShootTime;
        _soundManager.PlayOneShot(_shootSound);
        _controller.Shake(3, 5, 1f, 0, 0);
        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * _bulletSpeed;
    }
}
