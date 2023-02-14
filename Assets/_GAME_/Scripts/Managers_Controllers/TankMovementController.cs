using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TankMovementController : BaseMovementController
{
    public override void MoveSelectedObjToTargetPoint()           //eğer bike ve tank arasındaki movement şekli farklı olsaydı
                                                                  //değişiklikleri burada yapabileceğimizi göstermek açısından
                                                                  //bu classları oluşturup base movement da implemente ettim
    {
        if (_isObjectSelected)
        {
            _isTweening = true;
            _isMoving = false;
            transform.DOLookAt(_targetPointPosition, 1f).OnComplete(() =>
            {
                if (_isTargetInRange)
                {
                    _shootingBehaviour.Shoot(_targetTransform);
                }
                else if (!_isTargetInRange)
                {
                    _isMoving = true;
                    transform.DOMove(_targetPointPosition, _objData.ObjectsData.Speed).SetEase(Ease.Linear).SetSpeedBased(true).OnComplete(() =>
                    {
                        _isTweening = false;
                        _isMoving = false;
                    });
                }
            });
        }
    }
}
