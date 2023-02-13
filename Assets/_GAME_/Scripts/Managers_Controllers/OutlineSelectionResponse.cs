using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineSelectionResponse : MonoBehaviour, ISelectionResponse
{
    // ReSharper disable Unity.PerformanceAnalysis
    public void OnSelection(Transform selectedObject)
    {
        var selectedObjectOutline = selectedObject.GetComponent<Outline>();
        selectedObjectOutline.OutlineWidth = 3.5f;
    }

    public void OnDeselection(Transform selectedObject)
    {
        var selectedObjectOutline = selectedObject.GetComponent<Outline>();
        selectedObjectOutline.OutlineWidth = 0f;
    }

    
}
