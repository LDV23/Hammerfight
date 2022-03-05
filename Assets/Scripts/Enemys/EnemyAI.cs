using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _timeToReachSpeed = 1f;
    [SerializeField] private float _rotationSpeed;

    private Transform _playerTransform;

    void Awake()
    {
        _playerTransform = FindObjectOfType<PlayerController>().transform;
    }

    void FixedUpdate()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 force = _rigidbody.mass * (toPlayer * _speed - _rigidbody.velocity) / _timeToReachSpeed;
        _rigidbody.AddForce(force);

        Quaternion targetRotation = Quaternion.LookRotation(toPlayer, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
    }
}
