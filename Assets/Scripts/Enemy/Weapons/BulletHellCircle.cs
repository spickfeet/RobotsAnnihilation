using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BulletHellCircle : MonoBehaviour
{
    [SerializeField] private float _startAngle;
    [SerializeField] private float _endAngle;
    [SerializeField] private int _bulletsCount;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletSpawner;
    [SerializeField] private float _minBulletSpeed;
    [SerializeField] private float _maxBulletSpeed;
    [SerializeField] private int _bulletDamage;
    [SerializeField] private float _maxBulletSize;
    [SerializeField] private float _minBulletSize;

    [SerializeField] private float _nextShootTime;
    private float _nextShootTimer;

    public int BulletsCount 
    {  
        get { return _bulletsCount; } 
        set { _bulletsCount = value; }
    }

    public float MinBulletSpeed
    {
        get { return _minBulletSpeed; }
        set { _minBulletSpeed = value; }
    }

    public float MaxBulletSpeed
    {
        get { return _maxBulletSpeed; }
        set { _maxBulletSpeed = value; }
    }

    public int BulletDamage
    {
        get { return _bulletDamage; }
        set { _bulletDamage = value; }
    }

    public float MaxBulletSize
    {
        get { return _maxBulletSize; }
        set { _maxBulletSize = value; }
    }
    public float MinBulletSize
    {
        get { return _minBulletSize; }
        set { _minBulletSize = value; }
    }

    private void OnValidate()
    {
        if(_startAngle > _endAngle)
        {
            float buf;
            buf = _startAngle;
            _startAngle = _endAngle;
            _endAngle = buf;

        }
    }
    private void Awake()
    {
        _nextShootTimer = _nextShootTime;
    }

    public void Update()
    {
        if (_nextShootTimer <= 0)
        {
            Fire();
            _nextShootTimer = _nextShootTime;
        }
        else
        {
            _nextShootTimer -= Time.deltaTime;
        }
    }
    public void Fire()
    {
        float angularStep = (_endAngle - _startAngle)/ _bulletsCount;
        float currentAngular = angularStep;
        float preset = UnityEngine.Random.Range(0, 360);
        for (int i = 0; i < _bulletsCount; i++)
        {
            GameObject bulletGameObject = Instantiate(_bullet, _bulletSpawner.position, Quaternion.Euler(0, 0, currentAngular + preset));
            Bullet bullet = bulletGameObject.GetComponent<Bullet>();
            Light2D bulletLight = bullet.GetComponent<Light2D>();

            float bulletSize = Random.Range(MinBulletSize,MaxBulletSize);
            bulletGameObject.transform.localScale *= bulletSize;
            bulletLight.pointLightInnerRadius *= bulletSize;
            bulletLight.pointLightOuterRadius *= bulletSize;

            bullet.Damage = _bulletDamage;

            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * Random.Range(_minBulletSpeed,_maxBulletSpeed + 1);
            currentAngular += angularStep;
        }
    }
}

