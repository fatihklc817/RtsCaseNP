using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SelectManager : MonoBehaviour
{
    private ISelector _selector;

    private void Awake()
    {
        _selector = GetComponent<ISelector>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _selector.Check();
            var selectedObject = _selector.GetSelectedObject();
            if (selectedObject != null)
            {
                Debug.Log(selectedObject.name);
                
            }
        }
    }
}