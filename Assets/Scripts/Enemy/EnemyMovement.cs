using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _attackDistance;
    [SerializeField] private Player _player;
    private Vector3 _baseTarget;
    public Player Player
    {
        get { return _player; }
        set { _player = value; }
    }
    private NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _player = FindAnyObjectByType<Player>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _baseTarget = new Vector3(0, 0, 0);
        _navMeshAgent.stoppingDistance = _attackDistance * 0.9f;
        _navMeshAgent.speed = _speed;
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
    }
    private void Update()
    {
        if (_player == null)
        {
            _navMeshAgent.SetDestination(_baseTarget);
            return;
        }
        _navMeshAgent.SetDestination(_player.transform.position);
        
    }

}
