using DG.Tweening;
using UnityEngine;

public class TankShootingBehaviour : ShootingBehaviour
{
    public override void Update()                                                             //burada da aslında abstraction a gerek yoktu çünkü objeler aldığı dataya
    {                                                                                          // göre aynı şekilde çalışıyor. Ancak ileride tank ve bike arasındaki shooting 
        if (_isShootingStarted && Time.time > _nextFireTime)                                     // fonksiyonu değişirse diye bir base class yazdım.
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
