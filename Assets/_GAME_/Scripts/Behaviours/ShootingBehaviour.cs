using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ShootingBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private BulletDataSO _bulletData;

    [SerializeField] private ObjectData _objectData;

    private Transform _targetTransform;

    private bool _isShootingStarted;
    private float _nextFireTime = 0f;

    public void Shoot(Transform targetTransform)
    {
        _isShootingStarted = true;
        _targetTransform = targetTransform;
    }

    public void StopShooting()
    {
        _isShootingStarted = false;
    }

    private void Update()
    {
        if (_isShootingStarted && Time.time > _nextFireTime)
        {
            BuildingData targetData;
            if (_targetTransform == null)
            {
                StopShooting();
                return;
            }
            else
            {
                targetData = _targetTransform.GetComponent<BuildingData>();
            }

            if (targetData.Health <= 0)
            {
                StopShooting();
                return;
            }
            _nextFireTime = Time.time + _objectData.ObjectsData.FireRate;
            var bullet = Instantiate(_bulletData.BulletPrefab, _bulletSpawnPoint.position, Quaternion.identity);
            var position = _targetTransform.position;
            bullet.transform.LookAt(position);
            bullet.transform.DOMove(position, _bulletData.BulletSpeed).SetEase(Ease.Linear).SetId("shooting").SetSpeedBased(true).OnComplete((() =>
            {
                if (targetData != null)
                {
                    targetData.DecreaseHealth(_bulletData.Damage);
                    
                }
                Destroy(bullet.gameObject);
            }));
        }
    }
}
