using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private State _currentState;
    [SerializeField] float _attackDistance;
    [SerializeField] private PlayerMovement _target;
    private NavMeshAgent _navMeshAgent;

    public State CurrentState 
    { 
        get { return _currentState; } 
        set { _currentState = value; }
    }



    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.stoppingDistance = _attackDistance * 0.9f;
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
    }


    private void Update()
    {
        switch (_currentState)
        {
            default:
            case State.Run:
                _navMeshAgent.SetDestination(_target.transform.position);
                break;
            case State.Attack:
                break;
        }
    }

    public enum State
    {
        Run,Attack
    }
}
