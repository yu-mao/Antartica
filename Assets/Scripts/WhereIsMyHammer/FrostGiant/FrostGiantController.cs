using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FrostGiantController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Animator _animator;
    [SerializeField] private PatrolRoute _patrolRoute;
    [SerializeField] private float _stoppingDistanceThreshold = 0.5f;

    private bool _isMoving = false;
    private Transform _currentPoint;
    private int _routePointIndex = 0;
    
    // Start is called before the first frame update
    private void Start()
    {
        _currentPoint = _patrolRoute.points[_routePointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("Speed", _agent.velocity.magnitude);
        UpdatePatrol();
    }

    private void UpdatePatrol()
    {
        if (!_isMoving)
        {
            _routePointIndex++;
            if (_routePointIndex >= _patrolRoute.points.Count)
            {
                _routePointIndex = 0;
            }
            
            _currentPoint = _patrolRoute.points[_routePointIndex];
            _agent.SetDestination(_currentPoint.position);
            _isMoving = true;
        }
        
        if (_isMoving && Vector3.Distance(transform.position, _currentPoint.position) < _stoppingDistanceThreshold)
            _isMoving = false;
    }
}
