using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SelectManager : MonoBehaviour
{
    private ISelector _selector;
    private ISelectionResponse _selectionResponse;
    

    private IMovementController _movementController;

    private bool _isPressing;
    private bool _isAnyObjectSelected;
    private Transform _selectedObject;

    private void Awake()
    {
        _selector = GetComponent<ISelector>();
        _selectionResponse = GetComponent<ISelectionResponse>();

    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_isPressing)
        {
           
            _isPressing = true;
            
            _selector.Check();
            
            var newSelectedObj = _selector.GetSelectedObject();
            if (newSelectedObj != null)
            {
                if (_selectedObject != null)
                {
                  _selectionResponse.OnDeselection(_selectedObject);
                    
                }
                _selectedObject = newSelectedObj;
                _isAnyObjectSelected = false;
            }
            if (_selectedObject != null && !_isAnyObjectSelected)
            {
                _isAnyObjectSelected = true;
               _movementController = _selectedObject.GetComponent<IMovementController>();
                _selectionResponse.OnSelection(_selectedObject);
                _movementController.SetObjectSelected();
                
                
            }
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isPressing = false;
        }
    }
}