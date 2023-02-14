using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public abstract class ShootingBehaviour : MonoBehaviour, IShooting
{
    [SerializeField] protected Transform _bulletSpawnPoint;
    [SerializeField] protected BulletDataSO _bulletData;
    
    protected ObjectData _objectData;

    protected Transform _targetTransform;

    protected bool _isShootingStarted;
    protected float _nextFireTime = 0f;

    private void Start()
    {
        _objectData = GetComponent<ObjectData>();
    }

    public void Shoot(Transform targetTransform)
    {
        _isShootingStarted = true;
        _targetTransform = targetTransform;
    }

    public void StopShooting()
    {
        _isShootingStarted = false;
    }

    public abstract void Update();
}
