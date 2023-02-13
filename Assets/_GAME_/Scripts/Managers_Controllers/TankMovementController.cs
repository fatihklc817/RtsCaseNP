using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class TankMovementController : MonoBehaviour, IMovementController
{
    private ObjectData _objData;
    private Vector3 _targetPointPosition;
    private bool _isTargetBuilding;
    private int  _selectableObjectLayerIndex;
    private bool _isObjectSelected;
    private bool _isTweening;
    private bool _isTargetInRange;
    private bool _isMoving;

    private void Start()
    {
        _selectableObjectLayerIndex = LayerMask.NameToLayer("SelectableObjects");
    }

    public void SetObjectSelected()
    {
        _objData = GetComponent<ObjectData>();
        _isObjectSelected = true;
    }
    
    public void MoveSelectedObjToTargetPoint()
    {
        if (_isObjectSelected)
        {
            _isTweening = true;
            transform.DOLookAt(_targetPointPosition, 1f).OnComplete(() =>
            {
                if (_isTargetInRange)
                {
                    Debug.Log("gitmeden sıkıyomm");
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

    private void Update()
    {
        if (_isObjectSelected)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    Debug.DrawRay(ray.origin, ray.direction * 100f, Color.green, 2f);
                    if (hit.transform.gameObject.layer == _selectableObjectLayerIndex)
                    {
                        _isObjectSelected = false;
                        return;
                    }

                    if (_isTweening)
                    {
                        DOTween.KillAll();
                    }

                    _targetPointPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);

                    if (hit.transform.CompareTag("EnemyBuilding"))
                    {
                        _isTargetBuilding = true;
                    }
                    else
                    {
                        _isTargetBuilding = false;
                        _isTargetInRange = false;
                    }

                    MoveSelectedObjToTargetPoint();
                }
            }
            
            if (_isTargetBuilding)
            {
                var distance = (_targetPointPosition - transform.position).magnitude;
                if (distance <= _objData.ObjectsData.Range && _isTweening)
                {
                    _isTargetInRange = true;
                }
                
                if (_isMoving && _isTargetInRange)
                {
                    DOTween.KillAll();
                    _isMoving = false;
                    Debug.Log("geldim sıkıyorum");
                }
            }

            
        }
    }
    
    
    
}