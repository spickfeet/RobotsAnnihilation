using System.Collections;
using UnityEngine;

public class BossStageController : MonoBehaviour
{
    [SerializeField] private BulletHellCircle _bulletHellCircle;

    private Enemy _boss;
    private EnemyMovement _bossMovement;

    private int _currentStage = 1;

    private float _dashTime = 1f;

    private float _dashForce = 5;

    [SerializeField] private float _nextDashTime = 2;
    [SerializeField] private float _nextDashTimer;

    private Player _player;

    [SerializeField] private float _dashDistanceOfPlayer = 3;

    [SerializeField] private float _distanceOfPlayer;

    [SerializeField] private GameObject _medicKitPref;

    

    private void Awake()
    {
        _player = FindAnyObjectByType<Player>();
        _nextDashTimer = _nextDashTime;
        _boss = GetComponent<Enemy>();
        _boss.OnHealthChanged += StageControl;
        _bossMovement = GetComponent<EnemyMovement>();
    }

    public void StageControl()
    {
        if (_boss.CurrentHealth % 30f == 0)
        {
            Instantiate(_medicKitPref, transform.position, transform.rotation);
        }

        if (_boss.CurrentHealth * 3 <= _boss.MaxHealth && _currentStage == 1)
        {
            _bulletHellCircle.MaxBulletSpeed *= 2f;
            _bulletHellCircle.MaxBulletSize *= 1.3f;
            transform.localScale *= 1.2f;
            _bossMovement.Speed += 1f;

            _currentStage = 2;
        }
        if (_boss.CurrentHealth * 5 <= _boss.MaxHealth && _currentStage == 2)
        {

            _bulletHellCircle.MaxBulletSpeed *= 2f;
            _bulletHellCircle.MaxBulletSize *= 1.3f;
            transform.localScale *= 1.2f;
            _bossMovement.Speed += 2f;

            _currentStage = 3;
        }

        if (_boss.CurrentHealth * 10 <= _boss.MaxHealth && _currentStage == 3)
        {

            _bossMovement.Speed += 2f;

            _currentStage = 4;
        }
    }

    private void Update()
    {
        if (_player == null) return;
        _distanceOfPlayer = Vector3.Distance(_player.transform.position, transform.position);

        if (_distanceOfPlayer > _dashDistanceOfPlayer)
        {
            if (_nextDashTimer <= 0)
            {
                StartCoroutine(Dash());
                _nextDashTimer = _nextDashTime;

            }
        }
        if (_nextDashTimer > 0)
            _nextDashTimer -= Time.deltaTime;     

    }
    private IEnumerator Dash()
    {
        _bossMovement.Speed *= _dashForce;
        yield return new WaitForSeconds(_dashTime);
        _bossMovement.Speed /= _dashForce;
    }
}
