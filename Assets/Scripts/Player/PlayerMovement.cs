using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _dashForce;

    [SerializeField] private float _dashTime;
    [SerializeField] private float _dashCooldown;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;

    private Player _player;

    private float _currentDashTime = 0;
    [SerializeField] private float _nextDashTime = 0;


    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if (_currentDashTime > 0)
            _currentDashTime -= Time.deltaTime;

        if (_nextDashTime > 0)
        {
            _nextDashTime -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _nextDashTime <= 0)
        {
            Dash();
            _currentDashTime = _dashTime;
            _nextDashTime = _dashCooldown;
            return;
        }
    }

    private void FixedUpdate()
    {
        TurnTowardsCursor();

        if (_currentDashTime <= 0)
            Move();
    }

    public void Dash()
    {
        Vector2 dashPos = new Vector2();
        dashPos.x = Input.GetAxis("Horizontal");
        dashPos.y = Input.GetAxis("Vertical");
        _rigidbody2D.velocity = (dashPos.normalized * _dashForce);
        _player.ApplyImmortality(_dashTime);
    }

    private void Move()
    {
        Vector2 nextPos = new Vector2();
        nextPos.x = Input.GetAxis("Horizontal");
        nextPos.y = Input.GetAxis("Vertical");

        nextPos *= _speed;

        _rigidbody2D.velocity = nextPos;
    }
    public void TurnTowardsCursor()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        if (rotZ > 90 && rotZ < 180 || rotZ < -90 && rotZ > -180)
        {
            _spriteRenderer.flipX = true;
        }
        if (rotZ > -90 && rotZ < 90)
        {
            _spriteRenderer.flipX = false;
        }
    }
}
