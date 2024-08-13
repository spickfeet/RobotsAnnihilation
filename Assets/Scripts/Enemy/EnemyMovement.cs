using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _attackDistance;
    [SerializeField] private Player _player;
    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.stoppingDistance = _attackDistance * 0.9f;
        _navMeshAgent.speed = _speed;
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
    }
    private void Update()
    {
        _navMeshAgent.SetDestination(_player.transform.position);
    }
}
