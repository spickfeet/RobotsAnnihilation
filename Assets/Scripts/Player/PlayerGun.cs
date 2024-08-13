using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{

    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletSpeed;

    [SerializeField] private Transform _centerOfCircle;
    private PlayerWeaponRotation _weaponRotation = new();
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        (_centerOfCircle.transform.rotation, _spriteRenderer.flipY) = _weaponRotation.ChangeRotation(_centerOfCircle.transform.position, 0);
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * _bulletSpeed;
    }
}
