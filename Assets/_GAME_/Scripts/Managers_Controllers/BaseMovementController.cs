using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public abstract class BaseMovementController : MonoBehaviour, IMovementController 
{
    protected ShootingBehaviour _shootingBehaviour;
    
    protected ObjectData _objData;
    protected Vector3 _targetPointPosition;
    protected Transform _targetTransform;
    protected bool _isTargetBuilding;
    protected int  _selectableObjectLayerIndex;
    protected bool _isObjectSelected;
    protected bool _isTweening;
    protected bool _isTargetInRange;
    protected bool _isMoving;

    public void Start()
    {
        _selectableObjectLayerIndex = LayerMask.NameToLayer("SelectableObjects");
        _shootingBehaviour = GetComponent<ShootingBehaviour>();
    }

    public void SetObjectSelected()
    {
        Debug.Log(this.gameObject.name);
        _objData = GetComponent<ObjectData>();
        _isObjectSelected = true;
    }

    public abstract void MoveSelectedObjToTargetPoint();

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
                    else
                    {
                        _shootingBehaviour.StopShooting();
                    }

                    if (_isTweening)
                    {
                        transform.DOKill();
                    }

                    _targetPointPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);

                    if (hit.transform.CompareTag("EnemyBuilding"))
                    {
                        _isTargetBuilding = true;
                        _targetTransform = hit.transform;
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
                    transform.DOKill();
                    _isMoving = false;
                    _shootingBehaviour.Shoot(_targetTransform);
                    
                }
            }

            
        }
    }
    
    
    
}

